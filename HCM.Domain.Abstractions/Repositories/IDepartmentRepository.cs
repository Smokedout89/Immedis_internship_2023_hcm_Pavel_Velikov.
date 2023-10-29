namespace HCM.Domain.Abstractions.Repositories;

using Models;

public interface IDepartmentRepository : IRepository<Department>
{
    Task<Department?> GetDepartmentByName(string name);
}