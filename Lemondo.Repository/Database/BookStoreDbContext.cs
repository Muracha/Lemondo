namespace Lemondo.Repository.Database;

public sealed class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions options) : base(options) {  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ConfigureEntities();
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}
