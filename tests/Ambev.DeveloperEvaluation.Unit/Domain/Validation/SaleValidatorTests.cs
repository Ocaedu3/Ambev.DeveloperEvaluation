using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using System.Threading;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the UserValidator class.
/// Tests cover validation of all user properties including username, email,
/// password, phone, status, and role requirements.
/// </summary>
public class SaleValidatorTests
{
    private SaleValidator saleValidator;
    private ISaleValidationHelper _saleHelper;

    private readonly UserValidator _validator;

    public SaleValidatorTests()
    {
        _saleHelper = Substitute.For<ISaleValidationHelper>();
        saleValidator = new SaleValidator(_saleHelper);
    }

    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// This test verifies that a sale with valid data:
    /// - Valid CLientId
    /// - Valid BranchId
    /// - Valid ProductId for each item
    /// - Valid quantity and general data
    /// passes all validation rules without any errors.
    /// </summary>
    [Fact(DisplayName = "Valid sale should pass all validation rules")]
    public void ValidSale()
    {
        //var modal = Substitute.For<SaleValidator>();
        _saleHelper.verifyBranch(Arg.Any<long>()).Returns(true);
        _saleHelper.verifyClient(Arg.Any<long>()).Returns(true);
        _saleHelper.verifyProduct(Arg.Any<long>()).Returns(true);
        // Arrange
        var sale = SaleTestData.salesValidFake();

        // Act
        var result = saleValidator.TestValidate(sale);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails when ClientId is not found.
    /// </summary>
    [Fact(DisplayName = "Invalid client")]
    public void InvalidClientId()
    {
        // Arrange
        _saleHelper.verifyBranch(Arg.Any<long>()).Returns(true);
        _saleHelper.verifyClient(Arg.Any<long>()).Returns(false);
        _saleHelper.verifyProduct(Arg.Any<long>()).Returns(true);
        var sale = SaleTestData.salesValidFake();

        // Act
        var result = saleValidator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ClientId);
    }

    /// <summary>
    /// Tests that validation fails when BranchId is not found.
    /// </summary>
    [Fact(DisplayName = "Invalid branch")]
    public void InvalidBranchId()
    {
        // Arrange
        _saleHelper.verifyBranch(Arg.Any<long>()).Returns(false);
        _saleHelper.verifyClient(Arg.Any<long>()).Returns(true);
        _saleHelper.verifyProduct(Arg.Any<long>()).Returns(true);
        var sale = SaleTestData.salesValidFake();

        // Act
        var result = saleValidator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.BranchId);
    }

}
