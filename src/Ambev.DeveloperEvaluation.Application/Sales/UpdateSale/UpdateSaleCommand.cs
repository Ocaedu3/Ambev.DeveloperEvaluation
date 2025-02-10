using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command for creating a new user.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for updating a user, 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateSaleResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateSaleCommand : IRequest<UpdateSaleResult>
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
    public List<SalesProductUpdate>? SalesProducts { get; set; }
}

public class SalesProductUpdate
{
    /// <summary>
    /// The unique identifier of the sale item
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// The identifier of the Product of the sale item
    /// </summary>
    public long ProductId { get; set; }
    /// <summary>
    /// Quantity of the sale item
    /// </summary>
    public long Quantity { get; set; }
    /// <summary>
    /// Status of the sale item
    /// </summary>
    public bool Canceled { get; set; }
}


