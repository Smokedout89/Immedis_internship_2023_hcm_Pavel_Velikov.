namespace HCM.Domain.Repositories;

using MapsterMapper;
using PostgresModels;
using Abstractions.Models;
using Abstractions.Repositories;

public class UserRepository : Repository<User, UserDb>, IUserRepository
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users.FindAsync(email);

        return await Task.FromResult(_mapper.Map<User>(user!));
    }
}