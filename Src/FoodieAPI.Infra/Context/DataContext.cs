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
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserMap());
    }

  }
}