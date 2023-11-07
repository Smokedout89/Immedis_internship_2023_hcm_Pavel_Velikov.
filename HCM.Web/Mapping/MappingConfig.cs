namespace HCM.Web.Mapping;

using Models;
using Mapster;
using Responses;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EmployeesResponse, EmployeeModel>();
        config.NewConfig<DepartmentResponse, DepartmentModel>();
        config.NewConfig<TownResponse, TownModel>();
        config.NewConfig<SalaryResponse, SalaryModel>();
    }
}