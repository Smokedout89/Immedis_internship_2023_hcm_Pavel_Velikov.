namespace HCM.Domain.Repositories;

using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using PostgresModels;

public class RoleRepository : Repository<Role, RoleDb>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
    }
}