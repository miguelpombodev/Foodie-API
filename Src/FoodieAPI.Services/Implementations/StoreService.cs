using FoodieAPI.Domain.DTO.Responses;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Domain.Interfaces.Services;

namespace FoodieAPI.Services.Implementations
{
  public class StoreService : IStoreService
  {
    private readonly IStoreRepository _repository;

    public StoreService(IStoreRepository storeRepository)
    {
      _repository = storeRepository;
    }

    public async Task<List<StoreCategory>> GetStoreCategoriesListAsync()
    {
      var categoriesList = await _repository.GetStoreCategoriesListAsync();

      return categoriesList;
    }

    public async Task<List<StoreType>> GetStoreCategoriesTypesListAsync()
    {
      var storeTypesList = await _repository.GetStoreTypesListAsync();

      return storeTypesList;
    }

    public async Task<List<ListStoreResponseDto>> GetStoreListAsync(
      string? sortByOptionName,
      decimal? sortByDeliveryFee
      )
    {
      var storesList = await _repository.GetStoreListAsync(
        sortByOptionName,
        sortByDeliveryFee
        );

      return storesList;
    }
  }
}