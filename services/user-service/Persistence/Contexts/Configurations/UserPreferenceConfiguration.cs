using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations;

public class UserPreferenceConfiguration : IEntityTypeConfiguration<UserPreference>
{
    public void Configure(EntityTypeBuilder<UserPreference> builder)
    {
        builder.HasKey(upref => upref.Id);

        builder.Property(upref => upref.UserId)
            .IsRequired();

        builder.Property(upref => upref.Language)
            .IsRequired();

        builder.Property(upref => upref.Theme)
            .IsRequired();

        builder.Property(upref => upref.MarketingOptIn)
            .IsRequired();

        builder.HasIndex(upref => upref.UserId).IsUnique();
    }
}
