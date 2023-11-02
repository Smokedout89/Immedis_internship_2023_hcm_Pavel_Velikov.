namespace HCM.Web.Services.Contracts;

using Models;

public interface IIdentityService
{
    Task<HttpResponseMessage> RegisterUserAsync(RegisterModel model);
    Task<HttpResponseMessage> LoginUserAsync(LoginModel model);
}