var builder = WebApplication.CreateBuilder(args);
builder.ConfigureAppService();
var app = builder.Build();
app.ConfigureWebApplication().Run();
