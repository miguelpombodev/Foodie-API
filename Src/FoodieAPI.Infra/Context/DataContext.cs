using FoodieAPI.Domain.Entities;
using FoodieAPI.Infra.Configuration;
using FoodieAPI.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FoodieAPI.Infra.Context
{
  public class DataContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlServer(AppConfiguration.MainDatabaseConnectionString);
      
      if(AppConfiguration.IsDevelopment)
        options.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserMap());
      modelBuilder.ApplyConfiguration(new StoreCategoryMap());
      modelBuilder.ApplyConfiguration(new StoreTypeMap());
      modelBuilder.ApplyConfiguration(new StoreMap());
      modelBuilder.ApplyConfiguration(new ProductMap());
    }

  }
}