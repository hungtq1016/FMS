using Microsoft.EntityFrameworkCore;
using Infrastructure.Configurations;
using Shared.Entities;

namespace Infrastructure
{
    public class SharedContext : DbContext
    {
        public SharedContext() { }

        public SharedContext(DbContextOptions<SharedContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<ResetPassword> ResetPasswords => Set<ResetPassword>();
        public DbSet<Document> Documents => Set<Document>();
        public DbSet<Flight> Flights => Set<Flight>();
        public DbSet<Airport> Airports => Set<Airport>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();

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

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
        }
    }
}
