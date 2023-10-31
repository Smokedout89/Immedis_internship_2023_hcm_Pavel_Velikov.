namespace HCM.Domain.Abstractions.Repositories;

using Models;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee?> GetEmployeeByNames(string firstName, string lastName);
}