namespace HCM.Domain.Repositories;

using PostgresModels;
using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using Microsoft.EntityFrameworkCore;

public class DepartmentRepository : Repository<Department, DepartmentDb>, IDepartmentRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Department?> GetDepartmentByName(string name)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(
            n => n.Name == name);

        return _mapper.Map<Department>(department!);
    }
}