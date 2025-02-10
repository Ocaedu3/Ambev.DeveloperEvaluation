using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
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
    /// <summary>
    /// The list of itens of the sale
    /// </summary>
    public List<SalesProductGet> SalesProducts { get; set; }
    /// <summary>
    /// The final price of the sale whes it was created
    /// </summary>
    public decimal SalesFinalPrice { get; set; }
    /// <summary>
    /// The date of the operation
    /// </summary>
    public DateTime CreatedAt { get; set; }
}

public class SalesProductGet
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public long Quantity { get; set; }
    public decimal Discount { get; set; }
    public bool Canceled { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }

}