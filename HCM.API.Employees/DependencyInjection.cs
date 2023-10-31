namespace HCM.API.Employees;

using Swagger;
using Abstractions;
using Services.Town;
using Domain.Mapping;
using Services.Salary;
using Services.Course;
using Services.Address;
using Services.Employee;
using Services.Department;
using Services.LeaveRequest;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

public static class DependencyInjection
{
    public static IServiceCollection AddApiEmployees(
        this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbMappings();

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        //services.AddHttpClient("IdentityApi", client =>
        //{
        //    client.BaseAddress = new Uri("https://localhost:7211");
        //});

        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ILeaveRequestService, LeaveRequestService>();
        services.AddScoped<ISalaryService, SalaryService>();
        services.AddScoped<ITownService, TownService>();

        return services;
    }

    public static void RegisterEndpoints(this WebApplication app)
    {
        var endpoints = typeof(Program).Assembly
            .GetTypes()
            .Where(e => e.IsAssignableTo(
                typeof(IEndpoint)) && e is
                { IsAbstract: false, IsInterface: false })
            .Select(Activator.CreateInstance)
            .Cast<IEndpoint>();

        foreach (var endpoint in endpoints)
        {
            endpoint.RegisterEndpoints(app);
        }
    }
}