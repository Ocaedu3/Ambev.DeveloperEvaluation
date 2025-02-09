using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateUserRequest that defines validation rules for user creation.
/// </summary>
public class CreateSalesProductRequestValidator : AbstractValidator<List<SalesProductDTO>>
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
    public CreateSalesProductRequestValidator()
    {
        RuleForEach(salesproduct => salesproduct).NotEmpty().WithMessage("Branch ID is required");
        RuleForEach(salesproduct => salesproduct).Must(x => x.ProductId);
        //RuleFor(sale => sale.ClientId).NotEmpty().WithMessage("Client ID is required");
        //RuleFor(sale => sale.SalesProducts).NotEmpty().WithMessage("Sale must have be at least 1 item");
        //RuleForEach(sale => sale.SalesProducts).Where(x => x.Quantity > 20).Null().WithMessage("Quantity of any item have to be less than 20");
        //RuleForEach(sale => sale.SalesProducts).SetValidator(new SalesProductValidator());


        //RuleFor(sale => sale.SalesProducts).SetValidator(new QuantityValidator());
        //RuleFor(user => user.Username).NotEmpty().Length(3, 50);
        //RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        //RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        //RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
        //RuleFor(user => user.Role).NotEqual(UserRole.None);
    }
}