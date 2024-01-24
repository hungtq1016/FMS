using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Entities;

namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(user => user.Roles)
                .WithOne(userrole => userrole.User)
                .HasForeignKey(userrole => userrole.UserId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired(false);

            builder.HasOne(user => user.AvatarImage)
                .WithOne(image => image.User)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired(false);
        }
    }
}
