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
    public long Id { get; set; }
    public long ClientId { get; set; }
    public long BranchId { get; set; }
    public DateTime Date { get; set; }
    public List<SalesProductUpdate>? SalesProducts { get; set; }
}

public class SalesProductUpdate
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public long Quantity { get; set; }
    public bool Canceled { get; set; }
}


