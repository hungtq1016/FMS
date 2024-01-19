using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration config = builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("gateway.json",optional:false, reloadOnChange: true)
    .Build();

builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOcelot(config);

// In Configure method

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", () => "Hello from Gateway");
});

app.UseOcelot().Wait();

app.Run();
