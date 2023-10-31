namespace HCM.Domain.Repositories;

using PostgresModels;
using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : Repository<Employee, EmployeeDb>, IEmployeeRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Employee?> GetEmployeeByNames(string firstName, string lastName)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(
            e => e.FirstName == firstName && e.LastName == lastName);

        return _mapper.Map<Employee>(employee!);
    }
}