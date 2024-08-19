using FoodieAPI.Domain;
using FoodieAPI.Domain.DTO.Response;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Domain.Interfaces.Services;

namespace FoodieAPI.Services.Implementations;

public class ProductService(IProductRepository productRepository) : IProductsService
{
  public async Task<List<CustomUserProductResponseDto>> GetUserCustomsProductsListAsync(
    string storeTypeName,
    string? categoryTitle
  )
  {
    var products = await productRepository.GetUserCustomsProductsListAsync(
      storeTypeName, categoryTitle
    );

    return products;
  }
}
