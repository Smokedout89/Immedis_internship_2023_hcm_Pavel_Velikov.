namespace HCM.Domain.Abstractions.Repositories;

using Models;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
}