using FoodieAPI.Domain.Entities;
using FoodieAPI.Infra.Configuration;
using FoodieAPI.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FoodieAPI.Infra.Context
{
  public class DataContext : DbContext
  {

    // public DbSet<User> Users { get; set; }
    // public DbSet<Store> Stores { get; set; }
    // public DbSet<StoreCategory> StoreCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlServer(AppConfiguration.MainDatabaseConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserMap());
      modelBuilder.ApplyConfiguration(new StoreCategoryMap());
      modelBuilder.ApplyConfiguration(new StoreTypeMap());
      modelBuilder.ApplyConfiguration(new StoreMap());
    }

  }
}