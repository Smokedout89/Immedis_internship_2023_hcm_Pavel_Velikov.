namespace HCM.API.Identity.Features.Users.Responses;

public class CreateUserResponse
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}