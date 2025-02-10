using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for User entity operations
/// </summary>
public interface ISaleValidationHelper
{
    public bool verifyProduct(long Id);
    public bool verifyBranch(long Id);
    public bool verifyClient(long Id);

}
