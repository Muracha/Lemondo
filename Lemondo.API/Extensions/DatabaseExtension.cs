namespace Lemondo.API.Extensions;

public static class DatabaseExtension
{
    public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

        return builder;
    }
}
