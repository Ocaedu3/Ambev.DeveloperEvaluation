
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Command for deleting a sale by their ID
/// </summary>
public record DeleteSaleCommand : IRequest<DeleteSaleResponse>
{
    /// <summary>
    /// The unique identifier of the sale to delteted
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteUserCommand
    /// </summary>
    /// <param name="id">The id of the sale to delete</param>
    public DeleteSaleCommand(long id)
    {
        Id = id;
    }
}
