using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.DTO.Responses;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodieAPI.Infra.Repositories
{
  public class StoreRepository : IStoreRepository
  {
    protected readonly DataContext _DataContext;

    public StoreRepository(DataContext dataContext)
    {
      _DataContext = dataContext;
    }
    public async Task<List<StoreCategory>> GetStoreCategoriesListAsync()
    {
      List<StoreCategory> storeCategoriesList = await _DataContext.Set<StoreCategory>().ToListAsync();

      return storeCategoriesList;
    }

    public async Task<List<ListStoreResponseDTO>> GetStoreListAsync()
    {
      var storesList = await _DataContext.Set<Store>().Join(
        _DataContext.Set<StoreType>(),
        store => store.StoreTypeId,
        storeType => storeType.Id,
        (store, storeType) => new
        {
          storeAvatar = store.Avatar,
          storeName = store.Name,
          storeTypeName = storeType.Name,
          storeRate = decimal.Parse("5.0")
        }
      ).Select(query => new ListStoreResponseDTO(query.storeAvatar, query.storeName, query.storeTypeName, query.storeRate)).ToListAsync();

      return storesList;
    }

    public async Task<List<StoreType>> GetStoreTypesListAsync()
    {
      List<StoreType> storeTypesList = await _DataContext.Set<StoreType>().Where(st => st.Avatar != null).ToListAsync();

      return storeTypesList;
    }
  }
}