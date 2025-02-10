using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a new sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a sale, 
/// including clientid, Branch id and Date. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateSaleResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    /// <summary>
    /// Gets or sets the ClientId of the sale to be created.
    /// </summary>
    public long ClientId { get; set; }
    /// <summary>
    /// Gets or sets the BranchId of the sale to be created.
    /// </summary>
    public long BranchId { get; set; }
    /// <summary>
    /// Gets or sets the Date of the sale to be created.
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// Gets or sets the SalesProductDTO of the sale to be created.
    /// </summary>
    public List<SalesProductDTO> SalesProducts { get; set; }
}
/// <summary>
/// Represents a item within a sale while creating a new one
/// </summary>
public class SalesProductDTO
{
    public long ProductId { get; set; }
    public long Quantity { get; set; }
}


