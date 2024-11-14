namespace FoodieAPI.Services.Models;

public class CreatedCartModel(Guid storeId, Guid cartId)
{
  public Guid StoreId { get; set; } = storeId;
  public Guid CartId { get; set; } = cartId;
}