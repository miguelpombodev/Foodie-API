using FoodieAPI.Domain.DTO.Response;

namespace FoodieAPI.Domain.Interfaces.Repositories
{
  public interface IProductRepository
  {
    Task<List<CustomUserProductResponseDto>> GetUserCustomsProductsListAsync(
      string storeTypeName,
      string? categoryTitle
    );
  }
}