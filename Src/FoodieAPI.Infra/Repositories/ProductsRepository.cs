using FoodieAPI.Domain.DTO.Response;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FoodieAPI.Infra;

public class ProductsRepository(DataContext dataContext) : IProductRepository
{
  private readonly DataContext _dataContext = dataContext;

  public async Task<List<CustomUserProductResponseDto>> GetUserCustomsProductsListAsync(
    string storeTypeName,
    string? categoryTitle
  )
  {
    var customProductsQuery = _dataContext.Set<StoreType>().Join(
      _dataContext.Set<Store>(),
      storeType => storeType.Id,
      store => store.StoreTypeId,
      (storeType, store) => new { storeType, store }
    ).Join(
      _dataContext.Set<Product>(),
      storeTypeJoinStore => storeTypeJoinStore.store.Id,
      product => product.StoreId,
      (storeTypeJoinStore, product) => new
      {
        storeTypeJoinStore,
        product
      }
    ).Join(
      _dataContext.Set<StoreCategory>(),
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

    var selectedFieldsQuery = customProductsQuery.Select(customProduct =>
      new CustomUserProductResponseDto(
        customProduct.storeJoinProduct.product.Avatar,
        customProduct.storeJoinProduct.product.Name,
        customProduct.storeJoinProduct.product.Value,
        customProduct.storeJoinProduct.storeTypeJoinStore.store.Avatar,
        customProduct.storeJoinProduct.storeTypeJoinStore.store.Name
      ));

    return await selectedFieldsQuery.ToListAsync();
  }
}
