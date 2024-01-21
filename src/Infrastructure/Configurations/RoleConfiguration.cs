using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Entities;

namespace Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(role => role.Permissions)
                .WithOne(permission => permission.Role)
                .HasForeignKey(permission => permission.RoleId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired(true);

            builder.HasMany(role => role.Users)
                .WithOne(userrole => userrole.Role)
                .HasForeignKey(userrole => userrole.RoleId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired(true);

        }
    }
}
