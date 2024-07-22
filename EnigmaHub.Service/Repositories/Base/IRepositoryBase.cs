using System.Linq.Expressions;

namespace EnigmaHub.Service.Repositories.Base;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    Task<T> Create(T entity);
    Task<List<T>> CreateRange(List<T> entities);
    T Update(T entity);
    List<T> UpdateRange(List<T> entities);
    T Delete(T entity);
    void DeleteRange(List<T> entities);
}