using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a log entityin the database
/// </summary>
public class LogEntity
{
    /// <summary>
    /// Gets the log's id.
    /// Its generated by the database during its creation.
    /// </summary>
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Required]
    /// <summary>
    /// Gets the log event description .
    /// Must not be null or empty
    /// </summary>
    public string Event { get; set; }
    /// <summary>
    /// Gets the date and time when the log was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    public LogEntity()
    {
        CreatedAt = DateTime.UtcNow;
    }
}