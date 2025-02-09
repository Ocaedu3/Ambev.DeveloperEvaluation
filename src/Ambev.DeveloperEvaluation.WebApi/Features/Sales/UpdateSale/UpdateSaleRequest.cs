using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class UpdateSaleRequest
{
    public long Id { get; set; }
    public long ClientId { get; set; }
    public long BranchId { get; set; }
    public DateTime Date { get; set; }
    public List<SalesProductUpdate>? SalesProducts { get; set; }
}