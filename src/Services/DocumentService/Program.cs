using DocumentService.Infrastructure;
using DocumentService.Infrastructure.Data;
using DocumentService.Models;
using ImageService.Infrastructure.Features;
using Infrastructure.EFCore.Extensions;
using Infrastructure.EFCore.Repository;
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
builder.Services.AddSqlServerDbContext<DocumentContext>(configuration.GetConnectionString("documentDB"));
builder.Services.AddCustomMapper<DocumentProfile>();

builder.Services.AddScoped<IRepository<Document>, DocumentRepository>();
builder.Services.AddScoped<IDocumentService,CDocumentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var context = services.GetRequiredService<DocumentContext>();

if (context.Database.GetPendingMigrations().Any())
{
    context.Database.Migrate();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
