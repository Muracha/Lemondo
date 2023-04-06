namespace Lemondo.Test.RepositoryTest;

public class BookRepositoryTest : RepositoryTestBase<Book, IBookRepository>
{
    private readonly ServiceProvider _serviceProvider;

    public BookRepositoryTest(DbFixture dbFixture)
    {
        _serviceProvider = dbFixture.ServiceProvider;
        StartUp();
    }

    private void StartUp()
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

        Model = book;
        Repository = _serviceProvider.GetRequiredService<IBookRepository>();
    }

    public override async Task UpdateAsync()
    {
        await Repository.InsertAsync(Model);
        await Repository.SaveChangesAsync();

        Model.IsTaken = false;
        Model.Title = "TestUpdate";
        Model.Description = "TestUpdate";
        Model.Rating = 9;

        Repository.Update(Model);
        await Repository.SaveChangesAsync();

        var updatedModel = Repository.Get(Model.Id);
        Assert.True(updatedModel.IsTaken == Model.IsTaken && updatedModel.Title == Model.Title && updatedModel.Description == Model.Description && updatedModel.Rating == Model.Rating);
    }
}

