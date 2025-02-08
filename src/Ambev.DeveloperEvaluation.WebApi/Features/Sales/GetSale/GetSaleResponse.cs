using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// API response model for GetUser operation
/// </summary>
public class GetSaleResponse
{
    public long SaleId { get; set; }
    public long ClientId { get; set; }
    public long BranchId { get; set; }
    public DateTime Date { get; set; }
    public List<SalesProductDTO> SalesProducts { get; set; }
}
