namespace HCM.Api.Identity.Endpoints;

using Abstractions;

using Features.Roles.Requests;
using Features.Users.Requests;

using MediatR;

public class UserEndpoints : IEndpoint
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapPost("api/roles", CreateRole);
        //.RequireAuthorization(policyNames: Roles.Admin.ToString());
        app.MapGet("api/users/{id}", GetUser);
        //.RequireAuthorization(policyNames: Roles.Admin.ToString());
        app.MapGet("api/users", GetUsers);
        //.RequireAuthorization(policyNames: Roles.Admin.ToString());
        app.MapPost("api/users/register", RegisterUser);
        app.MapPost("api/users/login", LoginUser);
        app.MapPut("api/users/{id}/promote", PromoteUser);
        //.RequireAuthorization(policyNames: Roles.Admin.ToString());
        app.MapDelete("/api/users/{id}", DeleteUser);
        //.RequireAuthorization(policyNames: Roles.Admin.ToString());
    }

    private static async Task<IResult> CreateRole(ISender sender, CreateRoleRequest request)
    {
        return await sender.Send(request);
    }

    private static async Task<IResult> GetUser(ISender sender, string id)
    {
        var request = new GetUserRequest { Id = id };

        return await sender.Send(request);
    }

    private static async Task<IResult> GetUsers(ISender sender)
    {
        var request = new GetUsersRequest();

        return await sender.Send(request);
    }

    private static async Task<IResult> LoginUser(ISender sender, LoginUserRequest request)
    {
        return await sender.Send(request);
    }

    private static async Task<IResult> RegisterUser(ISender sender, CreateUserRequest request)
    {
        return await sender.Send(request);
    }

    private static async Task<IResult> PromoteUser(ISender sender, string id)
    {
        var request = new PromoteUserRequest { Id = id };

        return await sender.Send(request);
    }

    private static async Task<IResult> DeleteUser(ISender sender, string id)
    {
        var request = new DeleteUserRequest { Id = id };

        return await sender.Send(request);
    }
}