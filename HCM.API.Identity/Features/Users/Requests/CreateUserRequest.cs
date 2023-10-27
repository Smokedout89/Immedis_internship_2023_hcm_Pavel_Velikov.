namespace HCM.Api.Identity.Features.Users.Requests;

using Infrastructure.Requests;

public class CreateUserRequest : BaseRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}