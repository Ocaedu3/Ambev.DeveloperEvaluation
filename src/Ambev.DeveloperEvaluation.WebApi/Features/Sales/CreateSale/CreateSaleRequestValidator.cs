using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateUserRequest that defines validation rules for user creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateUserRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be valid format (using EmailValidator)
    /// - Username: Required, length between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be Unknown
    /// - Role: Cannot be None
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.BranchId).NotEmpty().WithMessage("Branch ID is required");
        RuleFor(sale => sale.ClientId).NotEmpty().WithMessage("Client ID is required");
        RuleFor(sale => sale.SalesProducts).NotEmpty().WithMessage("Sale must have be at least 1 item");
        RuleForEach(sale => sale.SalesProducts)
            .ChildRules(salesProduct => salesProduct.RuleFor(x => x.Quantity).InclusiveBetween(1,19).WithMessage("Quantity of each item must be between 1 and 19"));
    }
}