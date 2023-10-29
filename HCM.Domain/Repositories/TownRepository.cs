namespace HCM.Domain.Repositories;

using PostgresModels;
using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using Microsoft.EntityFrameworkCore;

public class TownRepository : Repository<Town, TownDb>, ITownRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public TownRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Town?> GetTownByName(string name)
    {
        var town = await _context.Towns.FirstOrDefaultAsync(
            n => n.Name == name);

        return _mapper.Map<Town>(town!);
    }
}