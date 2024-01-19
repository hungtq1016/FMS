using Microsoft.EntityFrameworkCore;
using Shared.Entities;

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
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            var dbUser = Environment.GetEnvironmentVariable("DB_USER");
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

            var connectionString2 = $"Data Source=host.docker.internal,{dbPort};Database={dbName};User ID={dbUser};Password={dbPassword};Trusted_Connection=False;TrustServerCertificate=true";
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
