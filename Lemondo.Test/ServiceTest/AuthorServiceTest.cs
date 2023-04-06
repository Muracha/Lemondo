namespace Lemondo.Test.ServiceTest;

public class AuthorServiceTest : IClassFixture<DbFixture>
{
    private readonly ServiceProvider _serviceProvider;
    private readonly IAuthorService _authorService;

    public AuthorServiceTest(DbFixture dbFixture)
    {
        _serviceProvider = dbFixture.ServiceProvider;
        _authorService = _serviceProvider.GetRequiredService<IAuthorService>();
    }

    [Fact]
    public async Task Search()
    {
        Author author = new()
        {
            FirstName = "Michael",
            LastName = "Jackson",
            DateOfBirth = DateTime.Now
        };

        await _authorService.InsertAsync(author);
        await _authorService.SaveChangesAsync();

        var result = _authorService.SearchByName(author.FullName);
        Assert.True(result.Count() > 0);
    }
}
