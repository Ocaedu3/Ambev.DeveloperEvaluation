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
public class Product
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Required]
    [StringLength(250)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [StringLength(250)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; }
    [Required]
    public List<SalesProduct> SalesProduct { get; set; }
    public DateTime CreatedAt { get; set; }
    public Product()
    {
        CreatedAt = DateTime.UtcNow;
    }
}