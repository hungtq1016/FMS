using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System.Xml.Linq;

namespace AuthContext
{
    public class DataContext : DbContext
    {
        public DataContext(){}

        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<User> Users => Set<User>();
        public DbSet<ResetPassword> ResetPasswords => Set<ResetPassword>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=FlightManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
