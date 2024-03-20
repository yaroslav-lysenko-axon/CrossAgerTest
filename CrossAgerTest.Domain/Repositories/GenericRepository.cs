using System.Linq.Expressions;
using CrossAgerTest.Domain.Exceptions;
using CrossAgerTest.Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace CrossAgerTest.Domain.Repositories;

public abstract class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    private readonly DbSet<T> _dbSet;

    protected GenericRepository(DbSet<T> dbSet)
    {
        _dbSet = dbSet;
    }   
    
    public Task<List<T>> FindAll(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;
        if (includes.Any())
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return query.AsNoTracking().ToListAsync();
    }
    
    public T FindFirst(Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes)
    {
        try
        {
            IQueryable<T> query = _dbSet;
            
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query.First(predicate);
        }
        catch (Exception)
        {
            throw new EntityNotFoundException(typeof(T).Name);
        }
    }

    public T FindFirst(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object?>> include,
        bool noTracking = false)
    {
        try
        {
            IQueryable<T> query = _dbSet;

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            query = include(query);

            return query.First(predicate);
        }
        catch (Exception)
        {
            throw new EntityNotFoundException(typeof(T).Name);
        }
    }


    public ValueTask<EntityEntry<T>> InsertAsync(T entity)
    {
        return _dbSet.AddAsync(entity);
    }

    public EntityEntry<T> Update(T entity)
    {
        return _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entity)
    {
        _dbSet.UpdateRange(entity);
    }
}