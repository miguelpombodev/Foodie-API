using FoodieAPI.Infra.Models;

namespace FoodieAPI.Services.Models;

public class CreatedCartWithItemModels(Guid storeId, Guid cartId, List<CreatedCartItems> items)
  : CreatedCartModel(storeId, cartId)
{
  public IEnumerable<CreatedCartItems> Items { get; set; } = items;
}