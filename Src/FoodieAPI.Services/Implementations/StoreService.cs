using FoodieAPI.Domain.DTO.Requests;
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

    public async Task<List<StoreType>> GetStoreCategoriesTypesListAsync(AvatarImageType body)
    {
      List<StoreType> storeTypesList;

      if ( body == AvatarImageType.LongImage )
      {
        storeTypesList = await _repository.GetStoreTypesOnlyWithLongAvatarListAsync();

        return storeTypesList;
      }

      storeTypesList = await _repository.GetStoreTypesOnlyWithShortAvatarListAsync();

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