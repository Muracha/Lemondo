namespace Lemondo.Test.ServiceTest;

public class BookServiceTest : IClassFixture<DbFixture>
{
    private readonly ServiceProvider _serviceProvider;
    private readonly IBookService _service;

    public BookServiceTest(DbFixture dbFixture)
    {
        _serviceProvider = dbFixture.ServiceProvider;
        _service = _serviceProvider.GetRequiredService<IBookService>();
    }

    [Fact]
    public async Task Search()
    {
        Book book = new()
        {
            Description = "Test",
            IsTaken = true,
            Rating = 10,
            ReleaseDate = DateTime.Now,
            Title = "Test",
        };

        book.Photo = book.Photo.GenerateRandomBytes(20);

        await _service.InsertAsync(book);
        await _service.SaveChangesAsync();

        var result = _service.SearchByTitle(book.Title);
        Assert.True(result.Count() > 0);
    }
}
