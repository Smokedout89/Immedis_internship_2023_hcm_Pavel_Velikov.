using HCM.Infrastructure.Responses;

namespace HCM.Web.Common;

public class APILoginResponse
{
    public Payload Payload { get; set; } = null!;
    public ResponseStatus ResponseStatus { get; set; } = null!;
}

public class Payload
{
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}