using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
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
    public List<SalesProductDTO> SalesProducts { get; set; }
}