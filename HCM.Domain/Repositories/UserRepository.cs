namespace HCM.Domain.Repositories;

using MapsterMapper;
using PostgresModels;
using Abstractions.Models;
using Abstractions.Repositories;

public class UserRepository : Repository<User, UserDb>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == email);

        return await Task.FromResult(_mapper.Map<User>(user!));
    }
}