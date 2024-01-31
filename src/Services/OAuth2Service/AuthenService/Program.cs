using AuthenService.Infrastructure;
using Infrastructure.EFCore.Extensions;
using Infrastructure.EFCore.Repository;
using Infrastructure.OAuth2.Data;
using Infrastructure.OAuth2.Data.Services;
using Infrastructure.OAuth2.Models;

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

builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IRepository<User>, OAuth2Repository<User>>();

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
app.ConfigureExceptionHandler();

app.Run();
