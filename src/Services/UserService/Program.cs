using Infrastructure.EFCore.Repository;
using Infrastructure.EFCore.Service;
using Infrastructure.OAuth2.Models;
using Infrastructure.EFCore.Extensions;
using UserService.Infrastructure.Data;
using AuthorizeService.Features;

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
builder.Services.AddSqlServerDbContext<UserContext>(configuration.GetConnectionString("userDB"));
builder.Services.AddCustomMapper<UserProfile>();

builder.Services.AddScoped<IRepository<User>, UserRepository<User>>();
builder.Services.AddScoped(typeof(IService<,,>), typeof(Service<,,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
