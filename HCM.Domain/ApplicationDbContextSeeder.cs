using HCM.Domain.DataSeeder;

namespace HCM.Domain;

public class ApplicationDbContextSeeder : ISeeder
{
    public async Task SeedAsync(
        ApplicationDbContext context,
        IServiceProvider serviceProvider)
    {
        var seeders = new List<ISeeder>
        {
            new RoleSeeder(),
            new UserSeeder()
        };

        foreach (var seeder in seeders)
        {
            await seeder.SeedAsync(context, serviceProvider);
        }

        await context.SaveChangesAsync();
    }
}