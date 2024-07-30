namespace FoodieAPI.Domain.Interfaces.Repositories
{
  public interface IProductRepository
  {
    Task<List<Dictionary<string, dynamic>>> GetUserCustomsProductsListAsync(
      string storeTypeName,
      string categoryTitle
    );
  }
}