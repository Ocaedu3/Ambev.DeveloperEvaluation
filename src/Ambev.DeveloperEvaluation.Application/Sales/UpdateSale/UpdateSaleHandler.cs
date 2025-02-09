﻿using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handler for processing CreateUserCommand requests
/// </summary>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly IProductRepository _productRepository;
    private readonly ISaleRepository _repository;
    private readonly SaleValidator _validator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateUserCommand</param>
    public UpdateSaleHandler(SaleValidator validator, ISaleRepository repository, IProductRepository productRepository, IMapper mapper)
    {
        _validator = validator;
        _repository = repository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateUserCommand request
    /// </summary>
    /// <param name="command">The CreateUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
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
        return result;
    }

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
