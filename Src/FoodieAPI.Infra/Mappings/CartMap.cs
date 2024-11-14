using FoodieAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodieAPI.Infra.Mappings;

public class CartMap : IEntityTypeConfiguration<Cart>
{
  public void Configure(EntityTypeBuilder<Cart> builder)
  {
    builder.ToTable("carts");
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id).HasColumnType("UniqueIdentifier").IsRequired();
    builder.Property(x => x.UserId).HasColumnName("User_Id").HasColumnType("UniqueIdentifier")
      .IsRequired();
    builder.Property(x => x.StoreId).HasColumnName("Store_Id").HasColumnType("UniqueIdentifier")
      .IsRequired();
    builder.Property(x => x.CreatedAt).HasColumnName("Created_At").HasColumnType("DATETIME")
      .HasDefaultValue(DateTime.Now.ToUniversalTime()).IsRequired();
    builder.Property(x => x.UpdatedAt).HasColumnName("Updated_At").HasColumnType("DATETIME")
      .HasDefaultValue(DateTime.Now.ToUniversalTime()).IsRequired();

    builder.HasOne<User>(cart => cart.User).WithMany(user => user.Carts)
      .HasForeignKey(cart => cart.UserId).IsRequired();
    builder.HasMany(cart => cart.CartItems).WithOne(cartItem => cartItem.Cart)
      .HasForeignKey(cartItem => cartItem.CartId).IsRequired();
  }
}