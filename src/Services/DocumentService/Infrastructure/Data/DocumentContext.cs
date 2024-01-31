using DocumentService.Models;
using Infrastructure.EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace DocumentService.Infrastructure.Data
{
    public class DocumentContext : AppDbContext
    {
        public DocumentContext(DbContextOptions options) : base(options) { }
        public DbSet<Document> Documents => Set<Document>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
