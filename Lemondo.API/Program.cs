var builder = WebApplication.CreateBuilder(args);
builder.ConfigureDatabase().ConfigureAppService();
var app = builder.Build().ConfigureWebApplication();
app.Run();
