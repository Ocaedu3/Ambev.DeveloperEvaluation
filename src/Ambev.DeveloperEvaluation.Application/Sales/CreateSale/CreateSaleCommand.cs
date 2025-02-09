using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a new user.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a user, 
/// including username, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateUserResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateUserCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public long ClientId { get; set; }
    public long BranchId { get; set; }
    public DateTime Date { get; set; }
    public List<SalesProductDTO> SalesProducts { get; set; }


    //public ValidationResultDetail Validate()
    //{
    //    var validator = new CreateUserCommandValidator();
    //    var result = validator.Validate(this);
    //    return new ValidationResultDetail
    //    {
    //        IsValid = result.IsValid,
    //        Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
    //    };
    //}
}

public class SalesProductDTO
{
    public long ProductId { get; set; }
    public long Quantity { get; set; }
}