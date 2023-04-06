namespace Lemondo.Web.Extensions;

public static class IConfigurationExtension
{
    public static void ConfigureIConfiguration(this WebApplicationBuilder builder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        builder.Services.AddSingleton(configuration);
    }
}
