namespace Lemondo.Repository;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    private readonly BookStoreDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected RepositoryBase(BookStoreDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TEntity>();
    }

    public virtual TEntity Get(int id) =>
        _dbSet.Find(id) ?? throw new KeyNotFoundException($"Record with key {id} not found");

    public virtual IQueryable<TEntity> Set(Expression<Func<TEntity, bool>> predicate) =>
        _dbSet.Where(predicate);

    public virtual IQueryable<TEntity> Set() =>
        _dbSet;

    public virtual void Insert(TEntity entity) =>
        _dbSet.Add(entity);

    public virtual async Task InsertAsync(TEntity entity) =>
        await _dbSet.AddAsync(entity);
    
    public virtual void Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public virtual void Delete(int id) =>
        Delete(Get(id));

    public virtual void Delete(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        _dbSet.Remove(entity);
    }

    public int SaveChanges() =>
        _context.SaveChanges();

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();

    public void Dispose() =>
        _context.Dispose();
}