using FoodieAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodieAPI.Infra.Mappings
{
  public class StoreCategoryMap : IEntityTypeConfiguration<StoreCategory>
  {
    public void Configure(EntityTypeBuilder<StoreCategory> builder)
    {
      builder.ToTable("stores_categories");
      builder.HasKey(col => col.Id);

      builder.Property(col => col.Id).HasColumnType("UniqueIdentifier");
      builder.Property(col => col.Title).HasColumnName("Title").HasColumnType("NVARCHAR").HasMaxLength(30).IsRequired();
      builder.Property(col => col.StoreId).HasColumnName("Store_Id").HasColumnType("UniqueIdentifier").IsRequired();

      builder.HasOne(storeCategoryCol => storeCategoryCol.Store).WithMany(storeCol => storeCol.StoreCategories).HasConstraintName("FK_STORE_STORE_TYPE_ID").HasForeignKey(f => f.StoreId);
    }
  }
}