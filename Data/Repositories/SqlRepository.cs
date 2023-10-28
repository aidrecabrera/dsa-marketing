using System.Linq.Expressions;
using dsa_marketing.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Aneta.Data.Repositories;

public class SqlRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext? _context;
    private readonly DbSet<TEntity> _dbSet;

    public SqlRepository(DbContext? context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public TEntity GetById(int? id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        _dbSet.AddRange(entities);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}