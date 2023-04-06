using System.Linq.Expressions;

namespace Lemondo.Facade.ServiceInterfaces;

public interface IServiceBase<TEntity> where TEntity : class
{
    void Delete(int id);
    void Delete(TEntity entity);
    TEntity Get(int id);
    void Insert(TEntity entity);
    Task InsertAsync(TEntity entity);
    int SaveChanges();
    Task<int> SaveChangesAsync();
    IQueryable<TEntity> Set();
    IQueryable<TEntity> Set(Expression<Func<TEntity, bool>> predicate);
    void Update(TEntity entity);
}