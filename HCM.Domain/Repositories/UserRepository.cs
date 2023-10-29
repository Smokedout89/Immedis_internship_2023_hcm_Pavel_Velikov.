namespace HCM.Domain.Repositories;

using PostgresModels;
using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using Microsoft.EntityFrameworkCore;

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
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Email == email);

        return _mapper.Map<User>(user!);
    }
}