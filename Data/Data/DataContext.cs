using Microsoft.EntityFrameworkCore;
using Share.Entities;
using Share.Enums;
using System.Data;
using System.Drawing;

namespace Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions options): base(options) { }

        public DbSet<User> Users => Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Data Source=DESKTOP-OCBT336\\SQLEXPRESS;Initial Catalog=FlightManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        
        }

        public override int SaveChanges()
        {
            ApplyAuditInformation();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ApplyAuditInformation();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInformation()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is AbstractEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.Now; 

                if (entity.State == EntityState.Added)
                {
                    ((AbstractEntity)entity.Entity).Id = Guid.NewGuid().ToString();
                    ((AbstractEntity)entity.Entity).Enable = true;
                    ((AbstractEntity)entity.Entity).CreatedAt = now;
                }
                ((AbstractEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
