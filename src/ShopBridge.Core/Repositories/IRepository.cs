﻿using System.Linq.Expressions;

namespace ShopBridge.Core.Repositories;
public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> GetFirstOrDefaultAsync(
     Expression<Func<TEntity, bool>> predicate = null!,
        string includeProperties = null!
    );
    Task<IEnumerable<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> predicate = null!,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
        string includeProperties = null!
    );
    Task<TEntity> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveById(int id);
    void RemoveRange(IEnumerable<TEntity> entities);
}
