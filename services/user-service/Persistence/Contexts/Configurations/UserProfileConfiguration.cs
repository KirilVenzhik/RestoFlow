using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(uprof => uprof.Id);

        builder.Property(uprof => uprof.FullName)
            .IsRequired();

        builder.Property(uprof => uprof.PhoneNumber)
            .IsRequired();

        builder.Property(uprof => uprof.DateOfBirth)
            .IsRequired();

        builder.Property(uprof => uprof.CreatedAt)
            .IsRequired();
        
        builder.Property(uprof => uprof.UpdatedAt)
            .IsRequired();

        builder.HasOne(uprof => uprof.UserPreference)
            .WithOne(upref => upref.UserProfile)
            .HasForeignKey<UserPreference>(upref => upref.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(uprof => uprof.Addresses)
            .WithOne(ua => ua.UserProfile)
            .HasForeignKey(ua => ua.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
