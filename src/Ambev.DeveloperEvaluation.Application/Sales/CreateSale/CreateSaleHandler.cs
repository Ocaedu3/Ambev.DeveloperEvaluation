﻿using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateUserCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly IProductRepository _productRepository;
    private readonly ISaleRepository _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateUserCommand</param>
    public CreateSaleHandler(ISaleRepository repository, IProductRepository productRepository, IMapper mapper)
    {
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
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        //var existingUser = await _repository.GetByEmailAsync(command.Email, cancellationToken);
        //if (existingUser != null)
        //    throw new InvalidOperationException($"User with email {command.Email} already exists");

        var entity = _mapper.Map<Sale>(command);
        GetSaleProduct(ref entity);
        entity.SetFinalPrice();

        var created = await _repository.CreateAsync(entity, cancellationToken);
        var result = _mapper.Map<CreateSaleResult>(created);
        return result;
    }

    public void GetSaleProduct(ref Sale entity)
    {
        foreach (SalesProduct salesProduct in entity.SalesProducts)
        {
            salesProduct.Product = _productRepository.GetByIdAsync(salesProduct.ProductId).Result;
            salesProduct.setDiscount();
            salesProduct.SetPrice();
        }
    }
}
