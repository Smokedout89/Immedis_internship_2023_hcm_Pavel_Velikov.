namespace HCM.Domain.DataSeeder;

using PostgresModels;

public class AddressSeeder : ISeeder
{
    public async Task SeedAsync(
        ApplicationDbContext context,
        IServiceProvider serviceProvider)
    {
        if (context.Addresses.Any())
        {
            return;
        }

        var addresses = new List<AddressDb>
        {
            new()
            {
                Id = "5052e3b3-33ef-48fe-9d47-149fc124f7ec",
                CreatedOn = DateTime.UtcNow,
                StreetName = "James Bourchier",
                StreetNumber = 69,
                TownId = "5499b583-cdab-4465-a3c7-ba054dd90b92"
            },
            new()
            {
                Id = "96059f49-fcac-416c-ac48-84df8d673fc1",
                CreatedOn = DateTime.UtcNow,
                StreetName = "Marica",
                StreetNumber = 13,
                TownId = "71bbbb83-5f83-4047-9347-84075373633a"
            },
            new()
            {
                Id = "fdfdac82-c7a6-4728-91d9-25c80037afa7",
                CreatedOn = DateTime.UtcNow,
                StreetName = "Primorski",
                StreetNumber = 222,
                TownId = "09f77257-d9d6-4490-a221-bd94cf04d66b"
            },
            new()
            {
                Id = "56091c37-da39-4d13-8eb6-7d90ed2ef9e6",
                CreatedOn = DateTime.UtcNow,
                StreetName = "Hristo Botev",
                StreetNumber = 24,
                TownId = "eeecb37b-a503-4f3e-9414-d7a2d71e2a10"
            },
            new()
            {
                Id = "1b5e3b65-3da6-4282-b71d-21e03ae9b546",
                CreatedOn = DateTime.UtcNow,
                StreetName = "Pridunavski",
                StreetNumber = 420,
                TownId = "0ec68ab4-d3ed-4270-90f8-234de54cf861"
            }
        };

        await context.Addresses.AddRangeAsync(addresses);
        await context.SaveChangesAsync();
    }
}