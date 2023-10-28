namespace HCM.API.Employees;

using Abstractions;
using Domain.Mapping;
using Services.Department;
using Services.Town;

public static class DependencyInjection
{
    public static IServiceCollection AddApiEmployees(
        this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbMappings();

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