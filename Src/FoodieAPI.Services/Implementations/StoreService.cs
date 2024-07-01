using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Domain.Interfaces.Services;

namespace FoodieAPI.Services.Implementations
{
  public class StoreService : IStoreService
  {
    protected readonly IStoreRepository _repository;

    public StoreService(IStoreRepository storeRepository)
    {
      _repository = storeRepository;
    }

    public async Task<List<StoreCategory>> GetStoreCategoriesListAsync()
    {
      List<StoreCategory> categoriesList = await _repository.GetStoreCategoriesListAsync();

      return categoriesList;
    }
  }
}