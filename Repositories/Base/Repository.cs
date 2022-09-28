using avarice_backend.Entities.Base;
using avarice_backend.Repositories;
using avarice_backend.Specifications.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace avarice_backend.Repositories.Base
{
  public class Repository<EntityType, EntityBaseType> : IRepository<EntityType> where EntityType : EntityBase<EntityBaseType>
  {
    protected readonly avariceContext _dbContext;

    public Repository(avariceContext dbContext)
    {
      _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IReadOnlyList<EntityType>> GetAllAsync()
    {
      return await _dbContext.Set<EntityType>().ToListAsync();
    }

    public async Task<IReadOnlyList<EntityType>> GetAsync(ISpecification<EntityType> spec)
    {
      return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<int> CountAsync(ISpecification<EntityType> spec)
    {
      return await ApplySpecification(spec).CountAsync();
    }

    private IQueryable<EntityType> ApplySpecification(ISpecification<EntityType> spec)
    {
      return SpecificationEvaluator<EntityType, EntityBaseType>.GetQuery(_dbContext.Set<EntityType>().AsQueryable(), spec);
    }

    public async Task<IReadOnlyList<EntityType>> GetAsync(Expression<Func<EntityType, bool>> predicate)
    {
      return await _dbContext.Set<EntityType>().Where(predicate).ToListAsync();
    }

    public async Task<IReadOnlyList<EntityType>> GetAsync
    (
      Expression<Func<EntityType, bool>> predicate = null,
      Func<IQueryable<EntityType>, IOrderedQueryable<EntityType>> orderBy = null,
      string includeString = null,
      bool disableTracking = true
    )
    {
      IQueryable<EntityType> query = _dbContext.Set<EntityType>();
      if (disableTracking) query = query.AsNoTracking();

      if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

      if (predicate != null) query = query.Where(predicate);

      if (orderBy != null)
        return await orderBy(query).ToListAsync();
      return await query.ToListAsync();
    }

    public async Task<IReadOnlyList<EntityType>> GetAsync
    (
      Expression<Func<EntityType, bool>> predicate = null,
      Func<IQueryable<EntityType>,
      IOrderedQueryable<EntityType>> orderBy = null,
      List<Expression<Func<EntityType, object>>> includes = null,
      bool disableTracking = true
    )
    {
      IQueryable<EntityType> query = _dbContext.Set<EntityType>();
      if (disableTracking) query = query.AsNoTracking();

      if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

      if (predicate != null) query = query.Where(predicate);

      if (orderBy != null)
        return await orderBy(query).ToListAsync();

      return await query.ToListAsync();
    }

    public virtual async Task<EntityType> GetByIdAsync(long id)
    {
      return await _dbContext.Set<EntityType>().FindAsync(id);
    }

    public async Task<EntityType> AddAsync(EntityType entity)
    {
      _dbContext.Set<EntityType>().Add(entity);
      await _dbContext.SaveChangesAsync();
      return entity;
    }

    public async Task UpdateAsync(EntityType entity)
    {
      _dbContext.Entry(entity).State = EntityState.Modified;
      await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(EntityType entity)
    {
      _dbContext.Set<EntityType>().Remove(entity);
      await _dbContext.SaveChangesAsync();
    }
  }
}