namespace HCM.API.Identity.Features.Roles.Requests;

using HCM.Infrastructure.Requests;

public class CreateRoleRequest : BaseRequest
{
    public string Name { get; set; } = string.Empty;
}