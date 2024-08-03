using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain;

public interface IProductsService
{
  Task<List<Dictionary<string, dynamic>>> GetUserCustomsProductsListAsync(
    string storeTypeName,
    string? categoryTitle
  );
}
