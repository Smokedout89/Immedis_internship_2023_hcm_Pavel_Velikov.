namespace HCM.Domain.DataSeeder;

using Abstractions.Models.Enums;
using PostgresModels;

public class EmployeeSeeder : ISeeder
{
    public async Task SeedAsync(
        ApplicationDbContext context, 
        IServiceProvider serviceProvider)
    {
        if (context.Employees.Any())
        {
            return;
        }

        var employees = new List<EmployeeDb>
        {
            new()
            {
                Id = "d19f9e60-6265-4758-80f4-d93187b4b1b3",
                FirstName = "Petar",
                LastName = "Petrov",
                Age = 33,
                JobTitle = "Junior Recruiter",
                DateOfBirth = new DateOnly(1990, 10, 2),
                HireDate = new DateOnly(2023, 2, 5),
                Gender = GenderType.Male,
                ContractType = ContractType.PartTime,
                AddressId = "5052e3b3-33ef-48fe-9d47-149fc124f7ec",
                DepartmentId = "c4086ee5-7d87-412b-8370-3690b19bcbf7",
                SalaryId = "e91dc788-86c2-4dee-961a-040e8f15f469",
                CreatedOn = DateTime.UtcNow
            },
            new()
            {
                Id = "c3fbe94f-9916-4f60-a271-2ab26a4fdbe7",
                FirstName = "Georgi",
                LastName = "Georgiev",
                Age = 23,
                JobTitle = "Accountant",
                DateOfBirth = new DateOnly(2000, 5, 5),
                HireDate = new DateOnly(2022, 2, 13),
                Gender = GenderType.Male,
                ContractType = ContractType.PartTime,
                AddressId = "96059f49-fcac-416c-ac48-84df8d673fc1",
                DepartmentId = "3a156778-5f27-4ba6-b8bc-ce44dea329de",
                SalaryId = "e91dc788-86c2-4dee-961a-040e8f15f469",
                CreatedOn = DateTime.UtcNow
            },
            new()
            {
                Id = "9d2d9937-997f-40b8-9f01-1e6de320b3ea",
                FirstName = "Maria",
                LastName = "Marinova",
                Age = 34,
                JobTitle = "Financial advisor",
                DateOfBirth = new DateOnly(1989, 9, 10),
                HireDate = new DateOnly(2020, 5, 5),
                Gender = GenderType.Female,
                ContractType = ContractType.FullTime,
                AddressId = "fdfdac82-c7a6-4728-91d9-25c80037afa7",
                DepartmentId = "38a7505d-be88-44bd-af24-a9c8d492558b",
                SalaryId = "e049c2a5-9055-468e-acb0-93466b243aff",
                CreatedOn = DateTime.UtcNow
            },
            new()
            {
                Id = "275fc0bf-90ea-47ff-9438-7f301cd43f33",
                FirstName = "Joro",
                LastName = "Ignatov",
                Age = 28,
                JobTitle = "Full stack developer intern",
                DateOfBirth = new DateOnly(1995, 10, 10) ,
                HireDate = new DateOnly(2023, 2, 2),
                Gender = GenderType.Male,
                ContractType = ContractType.Intern,
                AddressId = "56091c37-da39-4d13-8eb6-7d90ed2ef9e6",
                DepartmentId = "a38cddca-4c2b-4c2a-a8d7-3a386258bbe1",
                SalaryId = "e91dc788-86c2-4dee-961a-040e8f15f469",
                CreatedOn = DateTime.UtcNow
            },
            new()
            {
                Id = "97c9c761-8f38-4283-8aa9-398e2801e408",
                FirstName = "Valeria",
                LastName = "Bosilkova",
                Age = 25,
                JobTitle = "Marketing specialist",
                DateOfBirth = new DateOnly(1992, 5, 13),
                HireDate = new DateOnly(2020, 9, 10),
                Gender = GenderType.Female,
                ContractType = ContractType.FullTime,
                AddressId = "1b5e3b65-3da6-4282-b71d-21e03ae9b546",
                DepartmentId = "7e632698-1eed-4986-b584-f0752c524165",
                SalaryId = "71f6076b-e56a-447d-bf17-b9f9eb2aa8e9",
                CreatedOn = DateTime.UtcNow
            }
        };

        await context.Employees.AddRangeAsync(employees);
        await context.SaveChangesAsync();
    }
}