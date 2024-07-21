using System.Linq.Expressions;
using EliteDomus.Domain.Data;

namespace EliteDomus.Service.Repositories.Base;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected ApplicationDbContext _applicationDbContext { get; set; }
    public RepositoryBase(ApplicationDbContext applicationDbContext)
    {
        this._applicationDbContext = applicationDbContext;
    }
    public IQueryable<T> FindAll() 
    {
        return this._applicationDbContext.Set<T>();
    }
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return this._applicationDbContext.Set<T>()
            .Where(expression);
    }
    public async Task<T> Create(T entity)
    {
        await this._applicationDbContext.Set<T>().AddAsync(entity);
        return entity;
    }
    
    public async Task<List<T>> CreateRange(List<T> entities)
    {
        await this._applicationDbContext.Set<T>().AddRangeAsync(entities);
        return entities;
    }
    
    public T Update(T entity)
    {
        this._applicationDbContext.Set<T>().Update(entity);
        return entity;
    }

    public List<T> UpdateRange(List<T> entities)
    {
        _applicationDbContext.Set<T>().UpdateRange(entities);
        return entities;
    }

    public T Delete(T entity)
    {
        this._applicationDbContext.Set<T>().Remove(entity);
        return entity;
    }

    public void DeleteRange(List<T> entities)
    {
        this._applicationDbContext.Set<T>().RemoveRange(entities);
    }
}