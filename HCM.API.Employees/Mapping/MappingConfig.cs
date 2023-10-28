namespace HCM.API.Employees.Mapping;

using Features.Town.Responses;
using Domain.Abstractions.Models;
using Features.Address.Responses;
using Mapster;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Address, AddressResponse>();
        config.NewConfig<Town, TownResponse>();
    }
}