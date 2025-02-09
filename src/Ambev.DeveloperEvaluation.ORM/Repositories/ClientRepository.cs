using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IUserRepository using Entity Framework Core
/// </summary>
public class ClientRepository : IClientRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of UserRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ClientRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new user in the database
    /// </summary>
    /// <param name="user">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    public async Task<Client> CreateAsync(Client client, CancellationToken cancellationToken = default)
    {
        await _context.Client.AddAsync(client, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return client;
    }

    /// <summary>
    /// Retrieves a user by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    public async Task<Client?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var result =  await _context.Client.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
        return result;
    }
    public async Task<bool> UpdateAsync(Client client, CancellationToken cancellationToken = default)
    {
        _context.Client.Update(client);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Deletes a user from the database
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the user was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var client = await GetByIdAsync(id, cancellationToken);
        if (client == null)
            return false;

        _context.Client.Remove(client);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
