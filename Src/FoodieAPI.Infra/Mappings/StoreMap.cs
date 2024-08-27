using FoodieAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodieAPI.Infra.Mappings;

public class StoreMap : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("stores");
        builder.HasKey(col => col.Id);

        builder.Property(col => col.Id).HasColumnType("UniqueIdentifier");
        builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("NVARCHAR").HasMaxLength(150).IsRequired();
        builder.Property(x => x.Avatar).HasColumnName("Avatar").HasColumnType("NVARCHAR").HasMaxLength(150)
            .IsRequired();
        builder.Property(x => x.StoreTypeId).HasColumnName("Store_Type_Id").HasColumnType("INT").IsRequired();
        builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("NVARCHAR").IsRequired();
        builder.Property(x => x.OrderMinValue).HasColumnName("Order_Min_Value").HasColumnType("DECIMAL").IsRequired();
        builder.Property(x => x.OpenAt).HasColumnName("Open_At").HasColumnType("TIME").IsRequired();
        builder.Property(x => x.ClosedAt).HasColumnName("Closed_At").HasColumnType("TIME").IsRequired();
        builder.Property(x => x.Address).HasColumnName("Address").HasColumnType("NVARCHAR").HasMaxLength(1000)
            .IsRequired();
        builder.Property(x => x.CNPJ).HasColumnName("CNPJ").HasColumnType("VARCHAR").HasMaxLength(16).IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("Created_At").HasColumnType("DATETIME")
            .HasDefaultValue(DateTime.Now.ToUniversalTime());
        builder.Property(x => x.UpdatedAt).HasColumnName("Updated_At").HasColumnType("DATETIME")
            .HasDefaultValue(DateTime.Now.ToUniversalTime());
        builder.Property(x => x.CEP).HasColumnName("CEP").HasColumnType("VARCHAR").HasMaxLength(8).IsRequired();
        builder.Property(x => x.StoreRate).HasColumnName("Store_Rate").HasColumnType("DECIMAL").IsRequired();
        builder.Property(x => x.StoreMinDeliveryTime).HasColumnName("Store_Min_Delivery_Time").HasColumnType("VARCHAR")
            .HasMaxLength(3).IsRequired();
        builder.Property(x => x.StoreMaxDeliveryTime).HasColumnName("Store_Max_Delivery_Time").HasColumnType("VARCHAR")
            .HasMaxLength(3).IsRequired();
        builder.Property(x => x.StoreDeliveryFee).HasColumnName("Store_Delivery_Fee").HasColumnType("DECIMAL")
            .IsRequired();
    }
}