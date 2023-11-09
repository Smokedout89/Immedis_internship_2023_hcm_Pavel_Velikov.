namespace HCM.Infrastructure;

using System.Text;
using System.Reflection;

using Domain;
using MediatR;
using Behaviors;
using Authentication;
using FluentValidation;
using Domain.Repositories;
using Domain.PostgresModels;
using Domain.Abstractions.Models;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Models.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString,
        ConfigurationManager configuration)
    {

        services.AddDbContext<ApplicationDbContext>(
            options =>
            {
                options.UseLazyLoadingProxies();
                options.UseNpgsql(connectionString);
            });

        services.AddAuth(configuration);
        services.AddRepositories();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetEntryAssembly()!));

        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetEntryAssembly());

        return services;
    }

    public static async void ApplicationSeeder(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await dbContext.Database.MigrateAsync();

        await new ApplicationDbContextSeeder()
            .SeedAsync(
                dbContext,
                serviceScope.ServiceProvider);
    }

    private static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddScoped(
            typeof(IRepository<Address>),
            typeof(Repository<Address, AddressDb>));
        services.AddScoped(
            typeof(IAddressRepository),
            typeof(AddressRepository));

        services.AddScoped(
            typeof(IRepository<Course>),
            typeof(Repository<Course, CourseDb>));
        services.AddScoped(
            typeof(ICourseRepository),
            typeof(CourseRepository));

        services.AddScoped(
            typeof(IRepository<Department>),
            typeof(Repository<Department, DepartmentDb>));
        services.AddScoped(
            typeof(IDepartmentRepository),
            typeof(DepartmentRepository));

        services.AddScoped(
            typeof(IRepository<Employee>),
            typeof(Repository<Employee, EmployeeDb>));
        services.AddScoped(
            typeof(IEmployeeRepository),
            typeof(EmployeeRepository));

        services.AddScoped(
            typeof(IRepository<LeaveRequest>),
            typeof(Repository<LeaveRequest, LeaveRequestDb>));
        services.AddScoped(
            typeof(ILeaveRequestRepository),
            typeof(LeaveRequestRepository));

        services.AddScoped(
            typeof(IRepository<Role>),
            typeof(Repository<Role, RoleDb>));
        services.AddScoped(
            typeof(IRoleRepository),
            typeof(RoleRepository));

        services.AddScoped(
            typeof(IRepository<Salary>),
            typeof(Repository<Salary, SalaryDb>));
        services.AddScoped(
            typeof(ISalaryRepository),
            typeof(SalaryRepository));

        services.AddScoped(
            typeof(IRepository<Town>),
            typeof(Repository<Town, TownDb>));
        services.AddScoped(
            typeof(ITownRepository),
            typeof(TownRepository));

        services.AddScoped(
            typeof(IRepository<User>),
            typeof(Repository<User, UserDb>));
        services.AddScoped(
            typeof(IUserRepository),
            typeof(UserRepository));

        return services;
    }

    private static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(
            configuration.GetSection("JwtSettings").Get<JwtSettings>());
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => 
                options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        jwtSettings.Secret))
            });

        services.AddAuthorization(auth =>
        {
            auth.AddPolicy(
                Policies.Admin.ToString(),
                policy => policy.RequireRole(
                    Roles.Admin.ToString()).RequireAuthenticatedUser().Build());
            auth.AddPolicy(
                Policies.User.ToString(),
                policy => policy.RequireRole(
                    Roles.User.ToString()).RequireAuthenticatedUser().Build());

            auth.AddPolicy(
                "Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireRole(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build());
        });

        return services;
    }
}