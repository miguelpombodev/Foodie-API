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
    string categoryTitle
  )
  {
    List<Dictionary<string, dynamic>> formattedList = [];

    var x = await _DataContext.Set<StoreType>().Join(
      _DataContext.Set<Store>(),
      st => st.Id,
      s => s.StoreTypeId,
      (st, s) => new { st, s }
    ).Join(
      _DataContext.Set<Product>(),
      firstJoin => firstJoin.s.Id,
      product => product.StoreId,
      (firstJoin, product) => new
      {
        firstJoin,
        product
      }
    ).Join(
      _DataContext.Set<StoreCategory>(),
      secondJoin => secondJoin.product.StoreCategoryId,
      storeCategory => storeCategory.Id,
      (secondJoin, storeCategory) => new
      {
        secondJoin,
        storeCategory
      }
    ).Where(
      p => p.secondJoin.firstJoin.st.Name == storeTypeName
    ).Where(p => p.storeCategory.Title == categoryTitle).Select(p => new
    {
      p.secondJoin.product.Avatar,
      p.secondJoin.product.Name,
    }).ToListAsync();

    foreach (var item in x)
    {
      var s = new Dictionary<string, dynamic> { { "name", item.Name }, { "avatar", item.Avatar } };

      formattedList.Add(s);
    }

    return formattedList;
  }
}
