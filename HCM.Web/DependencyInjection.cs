namespace HCM.Web;
public static class DependencyInjection
{
    public static IServiceCollection AddWeb(
        this IServiceCollection services)
    {
        services.AddControllersWithViews();

        return services;
    }
}