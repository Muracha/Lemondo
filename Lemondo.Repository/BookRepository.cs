namespace Lemondo.Repository;

public sealed class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(BookStoreDbContext context) : base(context) { }

    public override IQueryable<Book> Set(Expression<Func<Book, bool>> predicate) =>
        _dbSet.Include(x => x.Authors).Where(predicate);

    public override IQueryable<Book> Set() =>
        _dbSet.Include(x => x.Authors);

    public override Book Get(int id) =>
        _dbSet.Include(x => x.Authors).Where(x => x.Id == id).FirstOrDefault() ?? throw new KeyNotFoundException($"Record with key {id} not found");
}
