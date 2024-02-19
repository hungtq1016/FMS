using Infrastructure.EFCore.Repository;
using Infrastructure.EFCore.Service;
using Infrastructure.EFCore.Extensions;
using FlightService.Infrastructure.Data;
using FlightService.Models;
using FlightService.Infrastructure;
using FlightService.Infrastructure.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddMemoryCache();

builder.Services.AddJWT(configuration);
builder.Services.AddSqlServerDbContext<FlightContext>(configuration.GetConnectionString("flightDB"));
builder.Services.AddCustomMapper<FlightProfile>();

builder.Services.AddScoped<IRepository<Flight>, FlightRepository<Flight>>();
builder.Services.AddScoped<IRepository<Airport>, FlightRepository<Airport>>();
builder.Services.AddScoped(typeof(IService<,,>), typeof(Service<,,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var context = services.GetRequiredService<FlightContext>();

if (context.Database.GetPendingMigrations().Any())
{
    context.Database.Migrate();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.ConfigureExceptionHandler();
app.MapControllers();

app.Run();
