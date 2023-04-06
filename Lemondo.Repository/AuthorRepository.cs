namespace Lemondo.Repository;

public sealed class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(BookStoreDbContext context) : base(context) { }
}
