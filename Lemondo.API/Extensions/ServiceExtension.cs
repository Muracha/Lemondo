namespace Lemondo.API.Extensions;

public static class ServiceExtension
{
    public static WebApplicationBuilder ConfigureAppService(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
        builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IAuthorService, AuthorService>();
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Host.UseSerilog((hostContext, configuration) => configuration
               .ReadFrom.Configuration(hostContext.Configuration));

        return builder;
    }
}
