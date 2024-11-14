using FoodieAPI.Infra.Models;

namespace FoodieAPI.Services.Models;

public class CreatedCartItemModel(
  Guid id,
  Guid cartId,
  string name,
  int quantity,
  decimal value,
  string avatar) : CreatedCartItems(id, cartId, name, quantity, value, avatar)
{
}