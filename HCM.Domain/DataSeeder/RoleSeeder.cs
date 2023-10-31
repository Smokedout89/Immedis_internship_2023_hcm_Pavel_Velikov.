namespace HCM.Domain.DataSeeder;

using PostgresModels;

public class RoleSeeder : ISeeder
{
    public async Task SeedAsync(
        ApplicationDbContext context,
        IServiceProvider serviceProvider)
    {
        if (context.Roles.Any())
        {
            return;
        }

        var roles = new List<RoleDb>
        {
            new() { Id = "506c5148-ffaa-425a-8e39-543a8a494176", Name = "Admin" },
            new() { Id = "afa1e622-d20b-4d88-8645-da0886dddd40", Name = "User" }
        };

        await context.Roles.AddRangeAsync(roles);
        await context.SaveChangesAsync();
    }
}