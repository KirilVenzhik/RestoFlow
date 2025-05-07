using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations;

public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.HasKey(ua => ua.Id);

        builder.Property(ua => ua.UserId)
            .IsRequired();

        builder.Property(ua => ua.City)
            .IsRequired();

        builder.Property(ua => ua.Street)
            .IsRequired();

        builder.Property(ua => ua.Building)
            .IsRequired();

        builder.Property(ua => ua.Apartment);

        builder.Property(ua => ua.CreatedAt)
            .IsRequired();
    }
}
