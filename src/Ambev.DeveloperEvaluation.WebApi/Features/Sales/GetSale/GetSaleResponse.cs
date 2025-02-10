using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// API response model for GetSale operation
/// </summary>
public class GetSaleResponse
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
    /// The final price of the sale whes it was created
    /// </summary>
    public decimal SalesFinalPrice { get; set; }
    /// <summary>
    /// The list of itens of the sale
    /// </summary>
    public List<SalesProductGet> SalesProducts { get; set; }

}
