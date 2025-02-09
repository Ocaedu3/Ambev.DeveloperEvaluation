using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public DeleteSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
