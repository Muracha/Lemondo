namespace Lemondo.Service;

public class BookService : ServiceBase<Book, IBookRepository>, IBookService
{
    public BookService(IBookRepository repository) : base(repository) { }

    public IQueryable<Book> SearchByTitle(string title) =>
        _repository.Set(x => x.Title.Contains(title));
}
