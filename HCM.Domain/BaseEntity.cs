namespace HCM.Domain;

using System.ComponentModel.DataAnnotations;

public class BaseEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedOn { get; set; } 
    public bool IsDeleted { get; set; }
}