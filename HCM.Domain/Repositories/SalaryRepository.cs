namespace HCM.Domain.Repositories;

using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using PostgresModels;

public class SalaryRepository : Repository<Salary, SalaryDb>, ISalaryRepository
{
    public SalaryRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
    }
}