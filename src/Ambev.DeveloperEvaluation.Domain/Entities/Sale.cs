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

    public void SetFinalPrice()
    {
        SalesFinalPrice = (SalesProducts.Sum(x => x.Price));
    }


}