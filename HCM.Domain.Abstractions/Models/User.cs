namespace HCM.Domain.Abstractions.Models;

public class User : Model
{
    public string Email { get; set; } = string.Empty;

    public string PasswordSalt { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string RoleId { get; set; } = string.Empty;
}