using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving a sale by their ID
/// </summary>
public record GetSaleCommand : IRequest<GetSaleResult>
{
    /// <summary>
    /// The unique identifier of the salte to retrieve
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Initializes a new instance of GetSaleCommand
    /// </summary>
    /// <param name="id">The ID of the sale to retrieve</param>
    public GetSaleCommand(long id)
    {
        Id = id;
    }
}
