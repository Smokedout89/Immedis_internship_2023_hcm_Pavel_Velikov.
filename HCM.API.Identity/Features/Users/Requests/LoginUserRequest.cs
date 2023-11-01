namespace HCM.API.Identity.Features.Users.Requests;

using HCM.Infrastructure.Requests;

public class LoginUserRequest : BaseRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}