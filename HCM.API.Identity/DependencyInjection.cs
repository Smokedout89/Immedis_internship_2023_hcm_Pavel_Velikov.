namespace HCM.API.Identity;

using Abstractions;
using HCM.Domain.Mapping;
using Microsoft.Extensions.Options;
using Services.User;
using Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

public static class DependencyInjection
{
    public static IServiceCollection AddApiIdentity(
        this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbMappings();

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        services.AddScoped<IUserService, UserService>();

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