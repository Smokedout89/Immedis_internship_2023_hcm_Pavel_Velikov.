namespace HCM.Api.Identity.Services.User;

using Features.Users.Requests;

public interface IUserService
{
    Task<IResult> Register(CreateUserRequest request);
    Task<IResult> Login(LoginUserRequest request);
    Task<IResult> GetUser(string id);
    Task<IResult> GetUsers();
    Task<IResult> DeleteUser(string id);
    Task<IResult> PromoteUser(string id);
}