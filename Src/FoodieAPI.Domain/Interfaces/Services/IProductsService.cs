using FoodieAPI.Domain.DTO.Response;

namespace FoodieAPI.Domain.Interfaces.Services;

public interface IProductsService
{
  Task<List<CustomUserProductResponseDto>> GetUserCustomsProductsListAsync(
    string storeTypeName,
    string? categoryTitle
  );
}
