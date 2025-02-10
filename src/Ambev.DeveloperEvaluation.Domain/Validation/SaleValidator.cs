using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    private readonly ISaleValidationHelper _validator;

    public SaleValidator(ISaleValidationHelper validator)
    {
        _validator = validator;
        RuleFor(sale => sale.ClientId).Must(_validator.verifyClient).WithMessage(x => $"Invalid Client: " + x.ClientId.ToString());
        RuleFor(sale => sale.BranchId).Must(_validator.verifyBranch).WithMessage(x => $"Invalid Branch: " + x.BranchId.ToString());
        RuleForEach(sale => sale.SalesProducts)
            .ChildRules(salesProduct => salesProduct.RuleFor(x => x.ProductId).Must(_validator.verifyProduct).WithMessage(x => $"Invalid Product: " + x.ProductId.ToString()));
    }


}
