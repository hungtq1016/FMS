using AuthorizeService.Infrastructure.Services;
using Infrastructure.EFCore.Extensions;
using Infrastructure.EFCore.Repository;
using Infrastructure.EFCore.Service;
using Infrastructure.OAuth2.Data;
using Infrastructure.OAuth2.Features;
using Infrastructure.OAuth2.Models;
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
builder.Services.AddSqlServerDbContext<OAuth2Context>(configuration.GetConnectionString("userDB"));
builder.Services.AddCustomMapper<OAuth2Profile>();

builder.Services.AddScoped<IRepository<Role>, OAuth2Repository<Role>>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRepository<Permission>, OAuth2Repository<Permission>>();
builder.Services.AddScoped<IRepository<Group>, OAuth2Repository<Group>>();
builder.Services.AddScoped<IRepository<Assignment>, OAuth2Repository<Assignment>>();
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


app.ConfigureExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();
