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
    public long Quantity { get; set; }
    [Required]
    public decimal Discount { get; set; }
    [Required]
    public bool Canceled { get; set; }
    public Sale Sales { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public SalesProduct()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public void setDiscount()
    {
        if (Quantity >= 10)
        {
            Discount = 0.2m;
        }
        else
        {
            Discount = Quantity >= 4 ? 0.1m : 0;
        }
    }
    public void SetPrice()
    {
        Price = (this.Product.Price - (this.Product.Price * this.Discount)) * this.Quantity;
    }
}