namespace HCM.Api.Identity.Mapping;

using Features.Users.Responses;
using Features.Roles.Responses;
using Domain.Abstractions.Models;

using Mapster;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Role, CreateRoleResponse>();
        config.NewConfig<User, LoginUserResponse>();
    }
}