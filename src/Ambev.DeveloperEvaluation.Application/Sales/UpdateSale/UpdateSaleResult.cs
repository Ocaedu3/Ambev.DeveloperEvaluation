namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Represents the response returned after successfully creating a new sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateSaleResult
{
    public long Id { get; set; }
    public long ClientId { get; set; }
    public long BranchId { get; set; }
    public DateTime Date { get; set; }
    public List<SalesProductUpdate>? SalesProducts { get; set; }
}
