using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Validator for GetUserCommand
/// </summary>
public class DeleteSaleValidator : AbstractValidator<DeleteSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for GetDeleteCommand
    /// </summary>
    public DeleteSaleValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("User ID is required");
    }
}
