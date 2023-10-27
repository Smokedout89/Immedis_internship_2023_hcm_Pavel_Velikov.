namespace HCM.Domain.Repositories;

using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using PostgresModels;

public class TownRepository : Repository<Town, TownDb>, ITownRepository
{
    public TownRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
    }
}