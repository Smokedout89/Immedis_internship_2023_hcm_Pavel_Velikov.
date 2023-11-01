namespace HCM.API.Identity.Mapping;

using Features.Roles.Responses;
using Features.Users.Responses;
using HCM.Domain.Abstractions.Models;
using Mapster;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Role, CreateRoleResponse>();
        config.NewConfig<User, LoginUserResponse>();
    }
}