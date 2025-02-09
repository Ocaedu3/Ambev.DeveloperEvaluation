using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a user in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class LogEntity
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Required]
    public string Event { get; set; }
    public DateTime CreatedAt { get; set; }
    public LogEntity()
    {
        CreatedAt = DateTime.UtcNow;
    }
}