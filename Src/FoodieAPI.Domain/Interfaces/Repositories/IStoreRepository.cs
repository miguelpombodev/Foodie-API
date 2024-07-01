using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Repositories
{
  public interface IStoreRepository
  {
    Task<List<StoreCategory>> GetStoreCategoriesListAsync();
  }
}