namespace Lemondo.Test.DatabaseConfiguration;

public class DbFixture
{
    public ServiceProvider ServiceProvider { get; private set; }

    public DbFixture()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase("TestDb"));
        serviceCollection
            .AddSingleton<IAuthorRepository, AuthorRepository>();
        serviceCollection
            .AddSingleton<IBookRepository, BookRepository>();
        serviceCollection
            .AddScoped<IAuthorService, AuthorService>();
        serviceCollection
            .AddScoped<IBookService, BookService>();

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }
}
