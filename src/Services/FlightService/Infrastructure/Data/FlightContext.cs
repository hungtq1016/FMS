using FlightService.Models;
using Infrastructure.EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Infrastructure.Data
{
    public class FlightContext : AppDbContext
    {
        public FlightContext(DbContextOptions options) : base(options) { }
        public DbSet<Airport> Airports => Set<Airport>();
        public DbSet<Flight> Flights => Set<Flight>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
