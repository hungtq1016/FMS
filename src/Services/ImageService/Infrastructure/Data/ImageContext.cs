using ImageService.Models;
using Infrastructure.EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace ImageService.Infrastructure.Data
{
    public class ImageContext : AppDbContext
    {
        public ImageContext(DbContextOptions options) : base(options) { }
        public DbSet<Image> Images => Set<Image>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
