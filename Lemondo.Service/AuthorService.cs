namespace Lemondo.Service;

public class AuthorService : ServiceBase<Author, IAuthorRepository>, IAuthorService
{
    public AuthorService(IAuthorRepository repository) : base(repository) { }

    public IQueryable<Author> SearchByName(string fullName) =>
        _repository.Set(x => x.FullName.Contains(fullName));
}