using FoodieAPI.Domain.Entities;
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

    public async Task<List<Store>> GetStoreListAsync()
    {
      List<Store> storesList = await _DataContext.Set<Store>().Include(store => store.StoreCategories).ToListAsync();

      return storesList;
    }

    public async Task<List<StoreType>> GetStoreTypesListAsync()
    {
      List<StoreType> storeTypesList = await _DataContext.Set<StoreType>().ToListAsync();

      return storeTypesList;
    }
  }
}