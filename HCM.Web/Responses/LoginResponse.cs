namespace HCM.Web.Responses;

public class LoginResponse : BaseResponse<LoginPayload>
{
}

public class LoginPayload
{
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}