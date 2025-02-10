using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateUserCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly IProductRepository _productRepository;
    private readonly ISaleRepository _repository;
    private readonly SaleValidator _validator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="userRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleCommand</param>
    public CreateSaleHandler(SaleValidator validator, ISaleRepository repository, IProductRepository productRepository, IMapper mapper)
    {
        _validator = validator;
        _repository = repository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Sale>(command);

        Validate(entity);

        GetSaleProduct(ref entity);
        entity.SetFinalPrice();

        var created = await _repository.CreateAsync(entity, cancellationToken);
        var result = _mapper.Map<CreateSaleResult>(created);
        return result;
    }

    public void Validate(Sale entity)
    {
        var validationResult = _validator.Validate(entity);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
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
}
