using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Infra.Mappings
{
  public class UserMap : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("users");
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id).HasColumnType("UniqueIdentifier");
      builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("NVARCHAR").HasMaxLength(200).IsRequired();
      builder.Property(x => x.Phone).HasColumnName("Phone").HasColumnType("VARCHAR").HasMaxLength(12).IsRequired();
      builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
      builder.Property(x => x.CPF).HasColumnName("CPF").HasColumnType("VARCHAR").HasMaxLength(69).IsRequired();
      builder.Property(x => x.CreatedAt).HasColumnName("Created_At").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
      builder.Property(x => x.UpdatedAt).HasColumnName("Updated_At").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
    }
  }
}