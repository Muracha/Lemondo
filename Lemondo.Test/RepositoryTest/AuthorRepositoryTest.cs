namespace Lemondo.Test.RepositoryTest;

public class AuthorRepositoryTest : RepositoryTestBase<Author, IAuthorRepository>
{
    private readonly ServiceProvider _serviceProvider;

    public AuthorRepositoryTest(DbFixture dbFixture)
    {
        _serviceProvider = dbFixture.ServiceProvider;
        StartUp();
    }

    private void StartUp()
    {
        Author author = new()
        {
            FirstName = "Michael",
            LastName = "Jackson",
            DateOfBirth = DateTime.Now
        };

        Model = author;
        Repository = _serviceProvider.GetService<IAuthorRepository>();
    }

    public override async Task UpdateAsync()
    {
        await Repository.InsertAsync(Model);
        await Repository.SaveChangesAsync();

        Model.FirstName = "Mikheil";
        Model.LastName = "Murachashvili";

        Repository.Update(Model);
        await Repository.SaveChangesAsync();

        var result = Repository.Get(Model.Id);
        Assert.True(result.FirstName == Model.FirstName && result.LastName == Model.LastName);
    }
}
