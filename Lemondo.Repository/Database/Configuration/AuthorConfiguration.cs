namespace Lemondo.Repository.Database.Configuration;

public sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName)
               .IsRequired()
               .HasMaxLength(50);
        builder.Property(x=> x.LastName)
               .IsRequired()
               .HasMaxLength(50);
        builder.Property(x => x.FullName)
               .HasMaxLength(100);
        builder.HasIndex(x => x.FullName);
        builder.Property(x => x.DateOfBirth)
               .IsRequired();
        builder.HasMany(x => x.Books)
               .WithMany(y => y.Authors);
    }
}
