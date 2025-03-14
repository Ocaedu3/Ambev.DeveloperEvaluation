using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using OneOf.Types;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Threading;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="UpdateSaleHandler"/> class.
/// </summary>
public class UpdateSaleHandlerTests
{
    private readonly SaleValidator _validator;
    private readonly ISaleValidationHelper _validatorHelper;
    private readonly ISaleRepository _repository;
    private readonly IProductRepository _productRepository;
    private readonly ILogRepository _logRepository;
    private readonly IMapper _mapper;
    private readonly UpdateSaleHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public UpdateSaleHandlerTests()
    {
        _repository = Substitute.For<ISaleRepository>();
        _productRepository = Substitute.For<IProductRepository>();
        _logRepository = Substitute.For<ILogRepository>();
        _validatorHelper = Substitute.For<ISaleValidationHelper>();

        _validator = new SaleValidator(_validatorHelper);
        _mapper = Substitute.For<IMapper>();
        _handler = new UpdateSaleHandler(_validator, _repository, _productRepository, _logRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid sale update request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Valid sale with valid response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = UpdateSaleHandlerTestData.UpdateSaleCommandFake();
        var sale = UpdateSaleHandlerTestData.salesFake();
        var updateSaleResult = UpdateSaleHandlerTestData.UpdateSaleResultFake();

        _validatorHelper.verifyBranch(Arg.Any<long>()).Returns(true);
        _validatorHelper.verifyClient(Arg.Any<long>()).Returns(true);
        _validatorHelper.verifyProduct(Arg.Any<long>()).Returns(true);
        _repository.GetByIdAsync(sale.Id).Returns(sale);

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<UpdateSaleResult>(sale).Returns(updateSaleResult);
        _repository.UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        var result = await _handler.Handle(command, CancellationToken.None);

        // Then
        result.Should().NotBeNull();
        result.Id.Should().Be(sale.Id);
        await _repository.Received(1).UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid sale update request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid sale data When creating user Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new UpdateSaleCommand();

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
        var command = UpdateSaleHandlerTestData.UpdateSaleCommandFake();
        var sale = UpdateSaleHandlerTestData.salesFake();

        _validatorHelper.verifyBranch(Arg.Any<long>()).Returns(true);
        _validatorHelper.verifyClient(Arg.Any<long>()).Returns(true);
        _validatorHelper.verifyProduct(Arg.Any<long>()).Returns(true);
        _repository.UpdateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

        _mapper.Map<Sale>(command).Returns(sale);
        _repository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>()).Returns(sale);

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<Sale>(Arg.Is<UpdateSaleCommand>(c =>
            c.Id == command.Id &&
            c.BranchId == command.BranchId &&
            c.ClientId == command.ClientId &&
            c.SalesProducts == command.SalesProducts));
    }
}
