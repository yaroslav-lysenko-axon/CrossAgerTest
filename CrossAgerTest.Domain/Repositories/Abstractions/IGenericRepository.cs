using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace CrossAgerTest.Domain.Repositories.Abstractions;

public interface IGenericRepository<T>
    where T : class
{
    Task<List<T>> FindAll(params Expression<Func<T, object>>[] includes);

    T FindFirst(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    
    T FindFirst(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object?>> includes,
        bool noTracking = false);

    ValueTask<EntityEntry<T>> InsertAsync(T entity);
    
    EntityEntry<T> Update(T entity);

    void UpdateRange(IEnumerable<T> entity);
}