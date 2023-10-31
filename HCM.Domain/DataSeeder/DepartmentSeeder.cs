namespace HCM.Domain.DataSeeder;

using PostgresModels;

public class DepartmentSeeder : ISeeder
{
    public async Task SeedAsync(
        ApplicationDbContext context,
        IServiceProvider serviceProvider)
    {
        if (context.Departments.Any())
        {
            return;
        }

        var departments = new List<DepartmentDb>
        {
            new()
            {
                Id = "c4086ee5-7d87-412b-8370-3690b19bcbf7",
                CreatedOn = DateTime.UtcNow,
                Name = "Human Resources"
            },
            new()
            {
                Id = "a38cddca-4c2b-4c2a-a8d7-3a386258bbe1",
                CreatedOn = DateTime.UtcNow,
                Name = "IT"
            },
            new()
            {
                Id = "3a156778-5f27-4ba6-b8bc-ce44dea329de",
                CreatedOn = DateTime.UtcNow,
                Name = "Accounting"
            },
            new()
            {
                Id = "38a7505d-be88-44bd-af24-a9c8d492558b",
                CreatedOn = DateTime.UtcNow,
                Name = "Finance"
            },
            new()
            {
                Id = "7e632698-1eed-4986-b584-f0752c524165",
                CreatedOn = DateTime.UtcNow,
                Name = "Marketing"
            }
        };

        await context.Departments.AddRangeAsync(departments);
        await context.SaveChangesAsync();
    }
}