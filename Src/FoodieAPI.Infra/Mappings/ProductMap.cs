using FoodieAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodieAPI.Infra;

public class ProductMap : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.ToTable("products");
    builder.HasKey(col => col.Id);

    builder.Property(col => col.Id).HasColumnType("UniqueIdentifier");
    builder.Property(col => col.Name).HasColumnName("Name").HasColumnType("VARCHAR").HasMaxLength(150).IsRequired();
    builder.Property(col => col.Value).HasColumnName("Value").HasColumnType("DECIMAL").HasMaxLength(30).IsRequired();
    builder.Property(col => col.StoreId).HasColumnName("Store_Id").HasColumnType("UniqueIdentifier").IsRequired();
    builder.Property(col => col.Description).HasColumnName("Description").HasColumnType("VARCHAR").HasMaxLength(300).IsRequired();
    builder.Property(col => col.StoreCategoryId).HasColumnName("Store_Category_Id").HasColumnType("UniqueIdentifier").IsRequired();
    builder.Property(col => col.Weight).HasColumnName("Weight").HasColumnType("VARCHAR").HasMaxLength(8);
    builder.Property(col => col.PeopleServed).HasColumnName("PeopleServed").HasColumnType("INT").IsRequired();
    builder.Property(col => col.Avatar).HasColumnName("Avatar").HasColumnType("NVARCHAR").HasMaxLength(150).IsRequired();
    builder.Property(x => x.CreatedAt).HasColumnName("Created_At").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
    builder.Property(x => x.UpdatedAt).HasColumnName("Updated_At").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());

    builder.HasOne(product => product.Store).WithMany(store => store.Products).HasConstraintName("FK_PRODUCT_STORE").HasForeignKey(f => f.StoreId);
    builder.HasOne(product => product.StoreCategory).WithMany(storeCategory => storeCategory.Products).HasConstraintName("FK_PRODUCT_STORECATEGORY").HasForeignKey(f => f.StoreCategoryId);

  }
}
