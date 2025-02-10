using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// API response model for CreateUser operation
/// </summary>
public class UpdateSaleResponse
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// The identifier of the Client of the sale
    /// </summary>
    public long ClientId { get; set; }
    /// <summary>
    /// The identifier of the Branch of the sale
    /// </summary>
    public long BranchId { get; set; }
    public DateTime Date { get; set; }
    /// <summary>
    /// The list of itens of the sale
    /// </summary>
    public List<SalesProductUpdate>? SalesProducts { get; set; }
}
