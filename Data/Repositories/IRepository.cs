using System.Linq.Expressions;
using System.Transactions;

namespace dsa_marketing.Data.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    TEntity GetById(int? id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}