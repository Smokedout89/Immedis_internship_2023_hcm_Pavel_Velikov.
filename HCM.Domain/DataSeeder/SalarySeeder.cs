namespace HCM.Domain.DataSeeder;

using PostgresModels;

public class SalarySeeder : ISeeder
{
    public async Task SeedAsync(
        ApplicationDbContext context,
        IServiceProvider serviceProvider)
    {
        if (context.Salaries.Any())
        {
            return;
        }

        var salaries = new List<SalaryDb>
        {
            new()
            {
                Id = "e91dc788-86c2-4dee-961a-040e8f15f469",
                CreatedOn = DateTime.UtcNow,
                GrossSalary = 2000,
                BonusAvailable = false
            },
            new()
            {
                Id = "71f6076b-e56a-447d-bf17-b9f9eb2aa8e9",
                CreatedOn = DateTime.UtcNow,
                GrossSalary = 4000,
                BonusAvailable = false
            },
            new()
            {
                Id = "e049c2a5-9055-468e-acb0-93466b243aff",
                CreatedOn = DateTime.UtcNow,
                GrossSalary = 8000,
                BonusAvailable = false
            }
        };

        await context.Salaries.AddRangeAsync(salaries);
        await context.SaveChangesAsync();
    }
}