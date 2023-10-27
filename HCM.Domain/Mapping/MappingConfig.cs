namespace HCM.Domain.Mapping;

using Mapster;
using PostgresModels;
using Abstractions.Models;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Address, AddressDb>();
        config.NewConfig<Course, CourseDb>();
        config.NewConfig<Department, DepartmentDb>();
        config.NewConfig<Employee, EmployeeDb>();
        config.NewConfig<EmployeeCourse, EmployeeCourseDb>();
        config.NewConfig<LeaveRequest, LeaveRequestDb>();
        config.NewConfig<Role, RoleDb>();
        config.NewConfig<Salary, SalaryDb>();
        config.NewConfig<Town, TownDb>();
        config.NewConfig<User, UserDb>();
    }
}