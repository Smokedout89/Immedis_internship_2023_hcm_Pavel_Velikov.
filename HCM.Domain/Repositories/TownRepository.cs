namespace HCM.Domain.Repositories;

using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using PostgresModels;

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
        var town = await _context.Towns.FindAsync(name);

        return await Task.FromResult(_mapper.Map<Town>(town!));
    }
}