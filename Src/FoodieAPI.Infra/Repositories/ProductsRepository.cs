using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FoodieAPI.Infra;

public class ProductsRepository : IProductRepository
{

  protected readonly DataContext _DataContext;

  public ProductsRepository(DataContext dataContext)
  {
    _DataContext = dataContext;
  }

  public async Task<List<Dictionary<string, dynamic>>> GetUserCustomsProductsListAsync(
    string storeTypeName,
    string? categoryTitle
  )
  {
    var customProductsQuery = _DataContext.Set<StoreType>().Join(
      _DataContext.Set<Store>(),
      storeType => storeType.Id,
      store => store.StoreTypeId,
      (storeType, store) => new { storeType, store }
    ).Join(
      _DataContext.Set<Product>(),
      storeTypeJoinStore => storeTypeJoinStore.store.Id,
      product => product.StoreId,
      (storeTypeJoinStore, product) => new
      {
        storeTypeJoinStore,
        product
      }
    ).Join(
      _DataContext.Set<StoreCategory>(),
      storeJoinProduct => storeJoinProduct.product.StoreCategoryId,
      storeCategory => storeCategory.Id,
      (storeJoinProduct, storeCategory) => new
      {
        storeJoinProduct,
        storeCategory
      }
    ).Where(
      param => param.storeJoinProduct.storeTypeJoinStore.storeType.Name == storeTypeName
    );

    if (categoryTitle != null)
    {
      customProductsQuery = customProductsQuery.Where(param => param.storeCategory.Title == categoryTitle);
    }

    return await customProductsQuery.Select(param =>
    new Dictionary<string, dynamic> { { "name", param.storeJoinProduct.product.Name }, { "avatar", param.storeJoinProduct.product.Avatar } }).ToListAsync(); ;
  }
}
