using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IUserRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of UserRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new user in the database
    /// </summary>
    /// <param name="user">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    /// <summary>
    /// Retrieves a user by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    public async Task<Sale?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var result =  await _context.Sales.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
        return result;
    }
    public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        var result = _context.Sales.First(a => a.Id == sale.Id);

        result.BranchId = sale.BranchId;
        result.ClientId = sale.ClientId;
        foreach (var currentEntity in result.SalesProducts)
        {
            foreach (var newEntiy in sale.SalesProducts)
            {
                if (newEntiy.Id == currentEntity.Id)
                {
                    currentEntity.Price = newEntiy.Price;
                    currentEntity.Product= newEntiy.Product;
                    currentEntity.Quantity = newEntiy.Quantity;
                    currentEntity.Canceled = newEntiy.Canceled;
                    currentEntity.CreatedAt = newEntiy.CreatedAt;
                    currentEntity.Discount = newEntiy.Discount;
                }
            }
        }
        result.SetFinalPrice();
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    /// <summary>
    /// Deletes a user from the database
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the user was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

}
