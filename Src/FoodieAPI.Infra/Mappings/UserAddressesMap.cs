using FoodieAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodieAPI.Infra.Mappings;

public class UserAddressesMap : IEntityTypeConfiguration<UserAddresses>
{
    public void Configure(EntityTypeBuilder<UserAddresses> builder)
    {
        builder.ToTable("user_addresses");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnType("UniqueIdentifier").IsRequired();
        builder.Property(x => x.UserId).HasColumnName("User_Id").HasColumnType("UniqueIdentifier").IsRequired();
        builder.Property(x => x.Address).HasColumnName("Address").HasColumnType("NVARCHAR").HasMaxLength(300).IsRequired();
        builder.Property(x => x.Number).HasColumnName("Number").HasColumnType("NVARCHAR").HasMaxLength(10).IsRequired();
        builder.Property(x => x.AddressComplement).HasColumnName("Address_Complement").HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
        builder.Property(x => x.IsDefault).HasColumnName("Is_Default").HasColumnType("BIT").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("Created_At").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
        builder.Property(x => x.UpdatedAt).HasColumnName("Updated_At").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
    }
}