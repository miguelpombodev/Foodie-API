using FoodieAPI.Domain;
using FoodieAPI.Domain.Interfaces.Repositories;

namespace FoodieAPI.Services;

public class ProductService : IProductsService
{
  private readonly IProductRepository _repository;

  public ProductService(IProductRepository productRepository)
  {
    _repository = productRepository;
  }

  public async Task<List<Dictionary<string, dynamic>>> GetUserCustomsProductsListAsync(
    string storeTypeName,
    string? categoryTitle
  )
  {
    var products = await _repository.GetUserCustomsProductsListAsync(
      storeTypeName, categoryTitle
    );

    return products;
  }
}
