using FoodieAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodieAPI.Infra.Mappings;

public class OrderMap : IEntityTypeConfiguration<Orders>
{
  public void Configure(EntityTypeBuilder<Orders> builder)
  {
    builder.ToTable("orders");
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id).HasColumnType("UniqueIdentifier").IsRequired();
    builder.Property(x => x.UserId).HasColumnName("User_Id").HasColumnType("UniqueIdentifier").IsRequired();
    builder.Property(x => x.CartId).HasColumnName("Cart_Id").HasColumnType("UniqueIdentifier").IsRequired();
    builder.Property(x => x.PaidAt).HasColumnName("Paid_At").HasColumnType("DATETIME").IsRequired();
    builder.Property(x => x.CompletedAt).HasColumnName("Completed_At").HasColumnType("DATETIME").IsRequired();
    builder.Property(x => x.PaidById).HasColumnName("Paid_By_Id").HasColumnType("INT").IsRequired();
    builder.Property(x => x.SubTotalValue).HasColumnName("SubTotal_Value").HasColumnType("DECIMAL").IsRequired();
    builder.Property(x => x.DeliveryFeeValue).HasColumnName("Delivery_Fee_Value").HasColumnType("DECIMAL").IsRequired();
    builder.Property(x => x.TotalValue).HasColumnName("Total_Value").HasColumnType("DECIMAL").IsRequired();
    builder.Property(x => x.UserAddressId).HasColumnName("User_Address_Id").HasColumnType("UniqueIdentifier").IsRequired();
    builder.Property(x => x.CreatedAt).HasColumnName("Created_At").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime()).IsRequired();
    builder.Property(x => x.UpdatedAt).HasColumnName("Updated_At").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime()).IsRequired();

    builder.HasOne<User>(order => order.User).WithMany(user => user.Orders).HasForeignKey(order => order.UserId);
    builder.HasOne<Cart>(order => order.Cart).WithOne(cart => cart.Order).HasForeignKey<Orders>(order => order.CartId);
    builder.HasOne<UserAddresses>(order => order.UserAddress).WithMany(user => user.Orders).HasForeignKey(order => order.UserAddressId);
  }
}