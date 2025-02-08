using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a user in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SalesProduct
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Required]
    public long ProductId { get; set; }
    [Required]
    public Product Product { get; set; }
    [Required]
    public long Quantity { get; set; } = 0;
    [Required]
    public decimal Discount { get; set; } = 0;
    [Required]
    public bool Canceled { get; set; } = false;
    [Required]
    public Sale Sales { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public SalesProduct()
    {
        CreatedAt = DateTime.UtcNow;
    }
}