using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Entities;

namespace Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasOne(flight => flight.Loading)
                .WithMany(load => load.LoadingFlights)
                .HasForeignKey(flight => flight.LoadingId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            builder.HasOne(flight => flight.UnLoading)
                .WithMany(unload => unload.UnloadingFlights)
                .HasForeignKey(flight => flight.UnloadingId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired(true);

            builder.HasMany(flight => flight.Documents)
                .WithOne(document => document.Flight)
                .HasForeignKey(document => document.FlightId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired(false);
        }
    }
}
