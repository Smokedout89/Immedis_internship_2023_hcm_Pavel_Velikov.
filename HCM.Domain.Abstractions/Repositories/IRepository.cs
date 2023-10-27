namespace HCM.Domain.Abstractions.Repositories;

public interface IRepository<T> where T : Model
{
    Task<T?> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T model);
    Task<T> UpdateAsync(T model);
    Task<T?> DeleteAsync(string id);
    Task<T?> GetByIdAsNoTracking(string id);
}