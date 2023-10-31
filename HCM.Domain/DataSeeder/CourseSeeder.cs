namespace HCM.Domain.DataSeeder;

using PostgresModels;

public class CourseSeeder : ISeeder
{
    public async Task SeedAsync(
        ApplicationDbContext context, 
        IServiceProvider serviceProvider)
    {
        if (context.Courses.Any())
        {
            return;
        }

        var courses = new List<CourseDb>
        {
            new()
            {
                Id = "13f0041c-47db-406b-bc92-154089c05304",
                CreatedOn = DateTime.UtcNow,
                Name = "C# Advanced"
            },
            new()
            {
                Id = "46aa85a0-c671-4f30-8f91-a0b0b6d9820a",
                CreatedOn = DateTime.UtcNow,
                Name = "Java Advanced"
            },
            new()
            {
                Id = "0fde1d3d-81cf-4094-bb17-87e03ac505e7",
                CreatedOn = DateTime.UtcNow,
                Name = "JavaScript Advanced"
            }
        };

        await context.Courses.AddRangeAsync(courses);
        await context.SaveChangesAsync();
    }
}