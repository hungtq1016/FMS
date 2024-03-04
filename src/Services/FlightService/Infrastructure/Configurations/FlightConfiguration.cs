using FlightService.Models;
using Infrastructure.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightService.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(flight => flight.Id);

            builder.Property(flight => flight.Id).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.Property(flight => flight.CreatedAt).HasColumnType("datetime")
                .HasDefaultValueSql(Constants.DateTimeAlgorithm)
                .IsRequired(true);

            builder.Property(flight => flight.UpdatedAt).HasColumnType("datetime")
                .HasDefaultValueSql(Constants.DateTimeAlgorithm)
                .IsRequired(true);

            builder.Property(flight => flight.Enable)
                .HasDefaultValue(true)
                .IsRequired(true);

            builder.Property(flight => flight.Status)
               .HasDefaultValue(1)
               .IsRequired(true);

            builder.Property(flight => flight.DepartureDate).HasColumnType("datetime")
                .HasDefaultValueSql(Constants.DateTimeAlgorithm)
                .IsRequired(true);

            builder.Property(flight => flight.ArrivalDate).HasColumnType("datetime")
                .HasDefaultValueSql(Constants.DateTimeAlgorithm)
                .IsRequired(true);

            builder.HasOne(flight => flight.Loading)
                .WithMany(airport => airport.LoadingFlights)
                .HasForeignKey(flight => flight.LoadingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(true);

            builder.HasOne(flight => flight.Unloading)
                .WithMany(airport => airport.UnloadingFlights)
                .HasForeignKey(flight => flight.UnloadingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(true);
        }
    }
}
