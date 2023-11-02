namespace HCM.Web;

using APIServices;
using Microsoft.AspNetCore.Authentication.Cookies;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddControllersWithViews();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(100);
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

        services.AddScoped<AuthService>();
        services.AddScoped<EmployeeService>();

        services.AddHttpClient("APIAuthService",
            client =>
            {
                client.BaseAddress = new Uri(configuration["ApiIdentityBaseUrl"]!);
            });

        services.AddHttpClient("ApiEmployeeService",
            client =>
            {
                client.BaseAddress = new Uri(configuration["ApiEmployeeBaseUrl"]!);
            });

        return services;
    }
}