namespace HCM.API.Employees.Mapping;

using Features.Town.Responses;
using Domain.Abstractions.Models;
using Features.Address.Responses;
using Features.Course.Responses;
using Mapster;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Address, AddressResponse>();
        config.NewConfig<Course, CourseResponse>();
        config.NewConfig<Town, TownResponse>();
    }
}