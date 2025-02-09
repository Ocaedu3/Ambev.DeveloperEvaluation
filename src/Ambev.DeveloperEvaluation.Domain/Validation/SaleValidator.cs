using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    private readonly IProductRepository _productRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IClientRepository _clientRepository;
    public SaleValidator(IProductRepository productRepository, IBranchRepository branchRepository, IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
        _branchRepository = branchRepository;
        _productRepository = productRepository;

        RuleFor(sale => sale.ClientId).Must(verifyClient).WithMessage(x => $"Invalid Client: " + x.ClientId.ToString());
        RuleFor(sale => sale.BranchId).Must(verifyBranch).WithMessage(x => $"Invalid Branch: " + x.BranchId.ToString());
        RuleForEach(sale => sale.SalesProducts)
            .ChildRules(salesProduct => salesProduct.RuleFor(x => x.ProductId).Must(verifyProduct).WithMessage(x => $"Invalid Product: " + x.ProductId.ToString()));
    }

    public bool verifyProduct(long Id)
    {
        var result = _productRepository.GetByIdAsync(Id).Result;
        if(result != null)
            return true;
        return false;
    }

    public bool verifyBranch(long Id)
    {
        var result = _branchRepository.GetByIdAsync(Id).Result;
        if (result != null)
            return true;
        return false;
    }

    public bool verifyClient(long Id)
    {
        var result = _clientRepository.GetByIdAsync(Id).Result;
        if (result != null)
            return true;
        return false;
    }
}
