using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class GetSaleResult
{
    [Required]
    public long SaleId { get; set; }
    [Required]
    public long ClientId { get; set; }
    [Required]
    public long BranchId { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public List<SalesProductDTO> SalesProducts { get; set; }
}
