using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System.Threading;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogRepository _logRepository;
    private readonly ISaleRepository _repository;
    private readonly SaleValidator _validator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateUserHandler
    /// </summary>
    /// <param name="_repository">The sale repository</param>
    /// <param name="_productRepository">The log repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for SaleUserCommand</param>
    public UpdateSaleHandler(SaleValidator validator, ISaleRepository repository, IProductRepository productRepository,
        ILogRepository logRepository, IMapper mapper)
    {
        _validator = validator;
        _logRepository = logRepository;
        _repository = repository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the UpdateSaleCommand request
    /// </summary>
    /// <param name="command">The UpdateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Sale>(command);

        var validationResult = await _validator.ValidateAsync(entity, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        GetSaleProduct(ref entity);
        entity.SetFinalPrice();

        var created = await _repository.UpdateAsync(entity, cancellationToken);
        var result = _mapper.Map<UpdateSaleResult>(created);
        
        if(result != null && result.SalesProducts.Any())
            VerifyCanceled(command.SalesProducts,entity.Id);

        return result;
    }
    /// <summary>
    /// Fill the product entity for each SalesProduct id product
    /// </summary>
    /// <param name="salesProduct">SalesProduct</param>
    public void GetSaleProduct(ref Sale entity)
    {
        foreach (SalesProduct salesProduct in entity.SalesProducts)
        {
            var result = _productRepository.GetByIdAsync(salesProduct.ProductId).Result;
            if (result != null)
            {
                salesProduct.Product = result;
                salesProduct.setDiscount();
                salesProduct.SetPrice();
            }
        }
    }
    /// <summary>
    /// Log the the when itens or sales are canceled
    /// </summary>
    /// <param name="entity">List<SalesProductUpdate></param>
    /// <param name="SaleId">long</param>
    public void VerifyCanceled(List<SalesProductUpdate> entity, long SaleId)
    {
        var sale = _repository.GetByIdAsync(SaleId).Result;

        foreach (var item in entity)
        {
            if (item.Canceled == true)
            {
                LogEntity logItem = new LogEntity();
                logItem.Event = "Item cancelled: sale-" + SaleId + " product-" + item.ProductId;
                _logRepository.Create(logItem);
            }
        }

        var saleStatus = sale.SalesProducts.Count(a => a.Canceled == false);
        if (saleStatus == 0)
        {
            LogEntity logSale = new LogEntity();
            logSale.Event = "The sale-" + SaleId + " was cancelled";
            _logRepository.Create(logSale);
        }
        else
        {
            LogEntity logEntity = new LogEntity();
            logEntity.Event = "The sale-" + SaleId + " was edited";
            _logRepository.Create(logEntity);
        }

    }
}
