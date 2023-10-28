namespace HCM.Domain.Abstractions.Repositories;

using Models;

public interface ITownRepository : IRepository<Town>
{
    Task<Town?> GetTownByName(string name);
}