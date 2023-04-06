namespace Lemondo.Facade.ServiceInterfaces;

public interface IBookService : IServiceBase<Book>
{
    IQueryable<Book> SearchByTitle(string title);
}
