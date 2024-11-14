using FoodieAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodieAPI.Infra.Mappings;

public class CartItemMap : IEntityTypeConfiguration<CartItem>
{
  public void Configure(EntityTypeBuilder<CartItem> builder)
  {
    builder.ToTable("cart_items");
    builder.HasKey(x => x.Id);

    builder.Property(x => x.CartId).HasColumnName("Cart_Id").HasColumnType("UniqueIdentifier")
      .IsRequired();
    builder.Property(x => x.ProductId).HasColumnName("Product_Id").HasColumnType("UniqueIdentifier")
      .IsRequired();
    builder.Property(x => x.ProductAmount).HasColumnName("Product_Amount").HasColumnType("INT")
      .IsRequired();
    builder.Property(x => x.CreatedAt).HasColumnName("Created_At").HasColumnType("DATETIME")
      .HasDefaultValue(DateTime.Now.ToUniversalTime()).IsRequired();
    builder.Property(x => x.UpdatedAt).HasColumnName("Updated_At").HasColumnType("DATETIME")
      .HasDefaultValue(DateTime.Now.ToUniversalTime()).IsRequired();
  }
}