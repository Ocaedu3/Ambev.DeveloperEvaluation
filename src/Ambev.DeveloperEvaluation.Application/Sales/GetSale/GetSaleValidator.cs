using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Validator for GetUserCommand
/// </summary>
public class GetSaleValidator : AbstractValidator<GetSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for GetSaleCommand
    /// </summary>
    public GetSaleValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("User ID is required");
    }
}
