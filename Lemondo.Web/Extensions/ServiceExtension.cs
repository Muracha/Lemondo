namespace Lemondo.Web.Extensions
{
    public static class ServiceExtension
    {
        public static WebApplicationBuilder ConfigureAppService(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddControllersWithViews();
            builder.ConfigureIConfiguration();
            builder.Host.UseSerilog((hostContext, configuration) => configuration
                           .ReadFrom.Configuration(hostContext.Configuration));

            return builder;
        }
    }
}
