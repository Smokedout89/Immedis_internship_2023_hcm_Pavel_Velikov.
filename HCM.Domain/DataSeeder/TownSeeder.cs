namespace HCM.Domain.DataSeeder;

using PostgresModels;

public class TownSeeder : ISeeder
{
    public async Task SeedAsync(
        ApplicationDbContext context,
        IServiceProvider serviceProvider)
    {
        if (context.Towns.Any())
        {
            return;
        }

        var towns = new List<TownDb>
        {
            new()
            {
                Id = "5499b583-cdab-4465-a3c7-ba054dd90b92",
                CreatedOn = DateTime.UtcNow,
                Name = "Sofia"
            },
            new()
            {
                Id = "71bbbb83-5f83-4047-9347-84075373633a",
                CreatedOn = DateTime.UtcNow,
                Name = "Plovdiv"
            },
            new()
            {
                Id = "09f77257-d9d6-4490-a221-bd94cf04d66b",
                CreatedOn = DateTime.UtcNow,
                Name = "Varna"
            },
            new()
            {
                Id = "eeecb37b-a503-4f3e-9414-d7a2d71e2a10",
                CreatedOn = DateTime.UtcNow,
                Name = "Bourgas"
            },
            new()
            {
                Id = "0ec68ab4-d3ed-4270-90f8-234de54cf861",
                CreatedOn = DateTime.UtcNow,
                Name = "Ruse"
            }
        };

        await context.Towns.AddRangeAsync(towns);
        await context.SaveChangesAsync();
    }
}