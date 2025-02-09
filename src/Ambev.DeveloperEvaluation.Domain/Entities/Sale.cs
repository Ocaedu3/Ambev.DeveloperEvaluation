using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a user in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Required]
    public long ClientId { get; set; }
    [Required]
    public Client Client { get; set; }
    [Required]
    public long BranchId { get; set; }
    [Required]
    public Branch Branch { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public List<SalesProduct> SalesProducts { get; set; }
    [Required]
    public decimal SalesFinalPrice { get; set; }
    public DateTime CreatedAt { get; set; }


    public Sale()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
    public void SetFinalPrice()
    {
        SalesFinalPrice = (SalesProducts.Sum(x => x.Price));
    }

    /// <summary>
    /// Performs validation of the user entity using the UserValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Username format and length</list>
    /// <list type="bullet">Email format</list>
    /// <list type="bullet">Phone number format</list>
    /// <list type="bullet">Password complexity requirements</list>
    /// <list type="bullet">Role validity</list>
    /// 
    /// </remarks>
    //public ValidationResultDetail Validate()
    //{
    //    //var validator = new UserValidator();
    //    //var result = validator.Validate(this);
    //    //return new ValidationResultDetail
    //    //{
    //    //    IsValid = result.IsValid,
    //    //    Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
    //    //};
    //}

    /// <summary>
    /// Activates the user account.
    /// Changes the user's status to Active.
    /// </summary>

    /// <summary>
    /// Deactivates the user account.
    /// Changes the user's status to Inactive.
    /// </summary>
    public void Deactivate()
    {
        //Status = UserStatus.Inactive;
        //UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Blocks the user account.
    /// Changes the user's status to Blocked.
    /// </summary>
    public void Suspend()
    {
        //Status = UserStatus.Suspended;
        //UpdatedAt = DateTime.UtcNow;
    }
}