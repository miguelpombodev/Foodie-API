using FoodieAPI.Domain.DTO.Responses;
using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Repositories
{
  public interface IStoreRepository
  {
    Task<List<StoreCategory>> GetStoreCategoriesListAsync();
    Task<List<StoreType>> GetStoreTypesListAsync();
    Task<List<ListStoreResponseDTO>> GetStoreListAsync();
  }
}