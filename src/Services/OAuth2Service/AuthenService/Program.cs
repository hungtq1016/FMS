using Infrastructure.EFCore.Extensions;
using Infrastructure.EFCore.Repository;
using Infrastructure.OAuth2.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJWT(configuration);
builder.Services
    .AddSqlServerDbContext<OAuth2Context>(
        configuration.GetConnectionString("userDB"),
        null,
        svc => svc.AddRepository(typeof(Repository<>)));

builder.Services.AddRepository(typeof(IRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
