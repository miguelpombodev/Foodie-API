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

    public async Task<List<StoreType>> GetStoreCategoriesTypesListAsync()
    {
      List<StoreType> storeTypesList = await _repository.GetStoreTypesListAsync();

      return storeTypesList;
    }

    public async Task<List<Store>> GetStoreListAsync()
    {
      List<Store> storesList = await _repository.GetStoreListAsync();

      return storesList;
    }
  }
}