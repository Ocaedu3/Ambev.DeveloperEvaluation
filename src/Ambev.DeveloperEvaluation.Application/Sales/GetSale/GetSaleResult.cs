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
    public long Id { get; set; }
    public long ClientId { get; set; }
    public long BranchId { get; set; }
    public DateTime Date { get; set; }
    public List<SalesProductGet> SalesProducts { get; set; }
    public decimal SalesFinalPrice { get; set; }
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