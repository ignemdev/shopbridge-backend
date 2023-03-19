using Microsoft.EntityFrameworkCore;
using ShopBridge.Core.Repositories;
using System.Linq.Expressions;

namespace ShopBridge.Data.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> dbSet;
    public Repository(ShopBridgeContext db) => dbSet = db.Set<TEntity>();

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await dbSet.AddRangeAsync(entities);
        return entities;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null!, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, string includeProperties = null!)
    {
        IQueryable<TEntity> query = dbSet;

        if (predicate != default)
            query = query.Where(predicate);

        if (includeProperties != default)
        {
            foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(property);
        }

        if (orderBy != default)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id) => await dbSet.FindAsync(id);

    public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null!, string includeProperties = null!)
    {
        IQueryable<TEntity> query = dbSet;

        if (predicate != default)
            query = query.Where(predicate);

        if (includeProperties != default)
        {
            foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(property);
        }

        return await query.FirstOrDefaultAsync();
    }

    public void Remove(TEntity entity) => dbSet.Remove(entity);

    public void RemoveById(int id)
    {
        var dbEntity = dbSet.Find(id);

        if (dbEntity == default)
            return;

        Remove(dbEntity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities) => dbSet.RemoveRange(entities);
}
