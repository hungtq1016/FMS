using FlightService.Models;
using Infrastructure.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightService.Infrastructure.Configurations
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(airport => airport.Id);

            builder.Property(airport => airport.Id).HasColumnType("varchar")
                .HasMaxLength(36)
                .HasDefaultValueSql(Constants.UuidAlgorithm)
                .IsRequired(true);

            builder.Property(airport => airport.CreatedAt).HasColumnType("datetime")
                .HasDefaultValueSql(Constants.DateTimeAlgorithm)
                .IsRequired(true);

            builder.Property(airport => airport.UpdatedAt).HasColumnType("datetime")
                .HasDefaultValueSql(Constants.DateTimeAlgorithm)
                .IsRequired(true);

            builder.Property(airport => airport.Enable)
                .HasDefaultValue(true)
                .IsRequired(true);
        }
    }
}
