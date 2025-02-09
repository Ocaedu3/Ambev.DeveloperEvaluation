namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class DeleteSaleRequest
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public long Id { get; set; }
}
