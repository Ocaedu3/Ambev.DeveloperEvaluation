using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Validator for CreateUserRequest that defines validation rules for user creation.
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateUserRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - BranchId: Required
    /// - ClientId: Required
    /// - SalesProducts.Quantity: Must be between 1 and 19
    /// - SalesProducts.Canceled: Cannot be null
    /// </remarks>
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.BranchId).NotEmpty().WithMessage("Branch ID is required");
        RuleFor(sale => sale.ClientId).NotEmpty().WithMessage("Client ID is required");
        RuleForEach(sale => sale.SalesProducts)
            .ChildRules(salesProduct => salesProduct.RuleFor(x => x.Quantity).InclusiveBetween(1,19).WithMessage("Quantity of each item must be between 1 and 19"));
        RuleForEach(sale => sale.SalesProducts)
            .ChildRules(salesProduct => salesProduct.RuleFor(x => x.Canceled).NotNull().WithMessage("Canceled status of each item is required"));
    }
}