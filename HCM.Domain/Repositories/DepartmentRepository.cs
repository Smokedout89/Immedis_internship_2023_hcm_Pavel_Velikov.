namespace HCM.Domain.Repositories;

using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using PostgresModels;

public class DepartmentRepository : Repository<Department, DepartmentDb>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
    }
}