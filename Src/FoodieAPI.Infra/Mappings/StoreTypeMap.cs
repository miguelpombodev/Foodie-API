using FoodieAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodieAPI.Infra.Mappings
{
  public class StoreTypeMap : IEntityTypeConfiguration<StoreType>
  {
    public void Configure(EntityTypeBuilder<StoreType> builder)
    {
      builder.ToTable("store_types");
      builder.HasKey(x => x.Id);

      builder.Property(col => col.Id).HasColumnType("int");
      builder.Property(col => col.Name).HasColumnName("Name").HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
      builder.Property(x => x.CreatedAt).HasColumnName("Created_At").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
      builder.Property(x => x.UpdatedAt).HasColumnName("Updated_At").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
    }
  }
}