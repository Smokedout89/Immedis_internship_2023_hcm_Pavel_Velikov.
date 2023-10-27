namespace HCM.Domain.Repositories;

using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using PostgresModels;

public class EmployeeRepository : Repository<Employee, EmployeeDb>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
    }
}