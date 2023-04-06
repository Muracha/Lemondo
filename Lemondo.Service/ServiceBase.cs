namespace Lemondo.Service;

public abstract class ServiceBase<TEntity, TRepository> : IServiceBase<TEntity> where TEntity : class
    where TRepository : IRepositoryBase<TEntity>
{
    protected readonly TRepository _repository;

    protected ServiceBase(TRepository repository)
    {
        _repository = repository;
    }

    public virtual TEntity Get(int id) =>
        _repository.Get(id);

    public virtual IQueryable<TEntity> Set(Expression<Func<TEntity, bool>> predicate) =>
        _repository.Set(predicate);

    public virtual IQueryable<TEntity> Set() =>
        _repository.Set();

    public virtual void Insert(TEntity entity) =>
        _repository.Insert(entity);

    public virtual Task InsertAsync(TEntity entity) =>
        _repository.InsertAsync(entity);

    public virtual void Update(TEntity entity) =>
        _repository.Update(entity);

    public virtual void Delete(int id) =>
        _repository.Delete(id);

    public virtual void Delete(TEntity entity) =>
        _repository.Delete(entity);

    public int SaveChanges() =>
        _repository.SaveChanges();

    public Task<int> SaveChangesAsync() =>
        _repository.SaveChangesAsync();
}
