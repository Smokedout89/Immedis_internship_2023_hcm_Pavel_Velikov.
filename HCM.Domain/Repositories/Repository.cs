namespace HCM.Domain.Repositories;

using Abstractions;
using MapsterMapper;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HCM.Domain.Abstractions.Repositories;

public class Repository<TModel, TPostgres> : IRepository<TModel>
    where TModel : Model
    where TPostgres : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly DbSet<TPostgres> _dbSet;

    public Repository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _dbSet = _context.Set<TPostgres>();
    }

    protected IQueryable<TPostgres> AsNoTracking()
    {
        return _dbSet.AsNoTracking();
    }

    public async Task<TModel?> GetByIdAsNoTracking(string id)
    {
        _context.ChangeTracker.LazyLoadingEnabled = false;
        var entity = await AsNoTracking().Where(
            u => u.Id == id).FirstOrDefaultAsync();

        return _mapper.Map<TModel>(entity!);
    }

    public async Task<TModel?> GetByIdAsync(string id)
    {
        var entity = await _dbSet.FindAsync(id);

        return _mapper.Map<TModel>(entity!);
    }

    public async Task<IEnumerable<TModel>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();

        return entities
                .Where(e => !e.IsDeleted)
                .Select(entity => _mapper.Map<TModel>(entity))
                .ToList();
    }

    public async Task<TModel> AddAsync(TModel model)
    {
        var entity = _mapper.Map<TPostgres>(model);
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<TModel> UpdateAsync(TModel model)
    {
        var entity = _mapper.Map<TPostgres>(model);

        entity.UpdatedOn = DateTime.UtcNow;
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<TModel>(entity);
    }

    public async Task<TModel?> DeleteAsync(string id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity is not null)
        {
            entity.IsDeleted = true;
            entity.UpdatedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        return _mapper.Map<TModel>(entity!);
    }
}