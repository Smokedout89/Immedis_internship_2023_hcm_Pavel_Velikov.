namespace HCM.Domain.DataSeeder;

public interface ISeeder
{
    Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider);
}