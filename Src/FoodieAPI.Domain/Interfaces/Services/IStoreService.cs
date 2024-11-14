using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.DTO.Responses;
using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Services;

public interface IStoreService
{
  Task<List<StoreCategory>> GetStoreCategoriesListAsync();
  Task<List<StoreType>> GetStoreCategoriesTypesListAsync(
      AvatarImageType body
      );

  Task<List<ListStoreResponseDto>> GetStoreListAsync(
      string? sortByOptionName,
      decimal? sortByDeliveryFee
  );
}