namespace HCM.Web;

using Services;
using Domain.Mapping;
using Services.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddControllersWithViews();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddDbMappings();

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Auth/Login";
                //options.AccessDeniedPath = "/Auth/AccessDenied";
                options.SlidingExpiration = true;
            });

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(100);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IEmployeeService, EmployeeService>();

        services.AddHttpClient("IdentityService",
            client =>
            {
                client.BaseAddress = new Uri(configuration["ApiIdentityBaseUrl"]!);
            });

        services.AddHttpClient("EmployeeService",
            client =>
            {
                client.BaseAddress = new Uri(configuration["ApiEmployeeBaseUrl"]!);
            });

        return services;
    }
}