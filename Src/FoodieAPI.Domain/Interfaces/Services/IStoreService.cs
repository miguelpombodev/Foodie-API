using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Services
{
  public interface IStoreService
  {
    Task<List<StoreCategory>> GetStoreCategoriesListAsync();

  }
}