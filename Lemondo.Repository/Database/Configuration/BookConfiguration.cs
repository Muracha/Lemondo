namespace Lemondo.Repository.Database.Configuration;

internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x=> x.Title)
               .IsRequired()
               .HasMaxLength(100);
        builder.HasIndex(x => x.Title);
        builder.Property(x => x.Rating)
               .IsRequired();
        builder.Property(x => x.ReleaseDate)
               .IsRequired();
        builder.Property(x => x.Description)
               .IsRequired()
               .HasMaxLength(500);
    }
}
