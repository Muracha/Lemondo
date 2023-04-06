namespace Lemondo.Facade.ServiceInterfaces;

public interface IAuthorService : IServiceBase<Author>
{
    IQueryable<Author> SearchByName(string fullName);
}
