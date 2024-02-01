using Infrastructure.EFCore.Data;
using Infrastructure.OAuth2.Data.Configurations;
using Infrastructure.OAuth2.Models;
using Microsoft.EntityFrameworkCore;

namespace UserService.Infrastructure.Data
{
    public class UserContext : AppDbContext
    {
        public UserContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
        }
    }
}
