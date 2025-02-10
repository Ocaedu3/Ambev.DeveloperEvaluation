using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using OneOf.Types;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="CreateSaleHandler"/> class.
/// </summary>
public class CreateSaleHandlerTests
{
    private readonly SaleValidator _validator;
    private readonly ISaleValidationHelper _validatorHelper;
    private readonly ISaleRepository _repository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly CreateSaleHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateUserHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public CreateSaleHandlerTests()
    {
        _repository = Substitute.For<ISaleRepository>();
        _productRepository = Substitute.For<IProductRepository>();
        _validatorHelper = Substitute.For<ISaleValidationHelper>();

        _validator = new SaleValidator(_validatorHelper);
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateSaleHandler(_validator, _repository, _productRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid sale creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Valid sale with valid response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateSaleHandlerTestData.CreateSaleCommandFake();
        var sale = CreateSaleHandlerTestData.salesFake();

        _validatorHelper.verifyBranch(Arg.Any<long>()).Returns(true);
        _validatorHelper.verifyClient(Arg.Any<long>()).Returns(true);
        _validatorHelper.verifyProduct(Arg.Any<long>()).Returns(true);

        _mapper.Map<Sale>(command).Returns(CreateSaleHandlerTestData.salesFake());
        _mapper.Map<CreateSaleResult>(sale).Returns(CreateSaleHandlerTestData.CreateSaleResultFake());
        _repository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id);
        await _repository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid user creation request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid sale data When creating user Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateSaleCommand();

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<System.ArgumentNullException>();
    }


    /// <summary>
    /// Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid command When handling Then maps command to sale entity")]
    public async Task Handle_ValidRequest_MapsCommandToUser()
    {
        // Given
        var command = CreateSaleHandlerTestData.CreateSaleCommandFake();
        var sale = CreateSaleHandlerTestData.salesFake();

        _validatorHelper.verifyBranch(Arg.Any<long>()).Returns(true);
        _validatorHelper.verifyClient(Arg.Any<long>()).Returns(true);
        _validatorHelper.verifyProduct(Arg.Any<long>()).Returns(true);

        _mapper.Map<Sale>(command).Returns(sale);
        _repository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<Sale>(Arg.Is<CreateSaleCommand>(c =>
            c.BranchId == command.BranchId &&
            c.ClientId == command.ClientId &&
            c.Date == command.Date &&
            c.SalesProducts == command.SalesProducts));
    }
}
