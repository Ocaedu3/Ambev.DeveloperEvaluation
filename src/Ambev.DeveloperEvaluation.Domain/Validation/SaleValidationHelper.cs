using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidationHelper: ISaleValidationHelper
{
    private readonly IProductRepository _productRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IClientRepository _clientRepository;
    public SaleValidationHelper(IProductRepository productRepository, IBranchRepository branchRepository, IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
        _branchRepository = branchRepository;
        _productRepository = productRepository;
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
