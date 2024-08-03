using FoodieAPI.Domain.DTO.Responses;
using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Services;

public interface IStoreService
{
  Task<List<StoreCategory>> GetStoreCategoriesListAsync();
  Task<List<StoreType>> GetStoreCategoriesTypesListAsync();

  Task<List<ListStoreResponseDTO>> GetStoreListAsync(
      string? sortByOptionName,
      decimal? sortByDeliveryFee
  );
}