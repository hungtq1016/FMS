using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Entities;

namespace Infrastructure.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasMany(document => document.Versions)
                .WithOne(version => version.Document)
                .HasForeignKey(version => version.DocumentId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired(false);
        }
    }
}
