namespace HCM.Api.Identity.Features.Roles.Requests;

using Infrastructure.Requests;

public class CreateRoleRequest : BaseRequest
{
    public string Name { get; set; } = string.Empty;
}