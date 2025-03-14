using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a item of a sale in the system.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SalesProduct
{
    /// <summary>
    /// Gets the SalesProduct's id.
    /// Its generated by the database during its creation.
    /// </summary>
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    /// <summary>
    /// The identifier of the Product of the item of the sale
    /// </summary>
    [Required]
    public long ProductId { get; set; }
    /// <summary>
    /// Navigation property to get Product full data
    /// </summary>
    [Required]
    public Product Product { get; set; }
    /// <summary>
    /// The quantity of the Product of the item of the sale
    /// </summary>
    [Required]
    public long Quantity { get; set; }
    [Required]
    /// <summary>
    /// The discount of the Product of the item of the sale
    /// Its calculated in the setDiscount function
    /// </summary>
    public decimal Discount { get; set; }
    /// <summary>
    /// The status of the item in the sale
    /// </summary>
    [Required]
    public bool Canceled { get; set; }
    /// <summary>
    /// Navigation property to get sales full data of the product and biding to the sale entity
    /// </summary>
    public Sale Sales { get; set; }
    /// <summary>
    /// The  price of the Product of the item of the sale
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    /// Gets the date and time when the user was created.
    /// Its calculated in the SetPrice function
    /// </summary>
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