namespace HCM.Domain.DataSeeder;

using PostgresModels;

public class UserSeeder : ISeeder
{
    public async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        if (context.Users.Any())
        {
            return;
        }

        //var adminRole = await context.Roles.FindAsync("506c5148-ffaa-425a-8e39-543a8a494176");
        //var userRole = await context.Roles.FindAsync("afa1e622-d20b-4d88-8645-da0886dddd40");

        var users = new List<UserDb>
        {
            new()
            {
                Id = "5ab77ce3-0697-4334-aca1-acd4be2931bf",
                Email = "admin@test.bg",
                CreatedOn = DateTime.UtcNow,
                RoleId = "506c5148-ffaa-425a-8e39-543a8a494176",
                //Role = adminRole!,
                PasswordSalt = "qmHnlbC5B8a8EtAvvESY2w==",
                PasswordHash = "nsj4+eY6sTNLDfjbWt5cJkEZ9yBuE8lrRarvWXaV86o="
            },
            new()
            {
                Id = "f12c266d-dc67-4d04-8853-a18ea944c308",
                Email = "user@test.bg",
                CreatedOn = DateTime.UtcNow,
                RoleId = "afa1e622-d20b-4d88-8645-da0886dddd40",
                //Role = userRole!,
                PasswordSalt = "5pzDGf8VCt4F1ViWFBfEiA==",
                PasswordHash = "mdka8k+ec5crNVw4NiXMrxLdU20pjT0iBy7/VD8Va7I="
            }
        };

        await context.Users.AddRangeAsync(users);
        await context.SaveChangesAsync();
    }
}