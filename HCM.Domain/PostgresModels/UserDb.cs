namespace HCM.Domain.PostgresModels;

using System.ComponentModel.DataAnnotations.Schema;

public class UserDb : BaseEntity
{
    public string Email { get; set; } = string.Empty;

    public string PasswordSalt { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    [ForeignKey(nameof(RoleDb))] 
    public string RoleId { get; set; } = string.Empty;

    public virtual RoleDb Role { get; set; } = null!;
}