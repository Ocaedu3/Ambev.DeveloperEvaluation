namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents the response returned after successfully creating a new sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateSaleResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created sale.
    /// </summary>
    /// <value>A long autogenerate by database that uniquely identifies the created user in the system.</value>
    public long Id { get; set; }
    /// <summary>
    /// Gets or sets the ClientId of the sale to be created.
    /// </summary>
    public long ClientId { get; set; }
    /// <summary>
    /// Gets or sets the BranchId of the sale to be created.
    /// </summary>
    public long BranchId { get; set; }
    /// <summary>
    /// Gets or sets the SalesProductDTO of the sale to be created.
    /// </summary>
    public List<SalesProductDTO> SalesProducts { get; set; }
}
