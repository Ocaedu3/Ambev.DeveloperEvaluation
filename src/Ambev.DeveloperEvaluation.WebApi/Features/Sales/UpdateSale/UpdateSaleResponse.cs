using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// API response model for CreateUser operation
/// </summary>
public class UpdateSaleResponse
{
    public long Id { get; set; }
    public long ClientId { get; set; }
    public long BranchId { get; set; }
    public DateTime Date { get; set; }
    public List<SalesProductUpdate>? SalesProducts { get; set; }
}
