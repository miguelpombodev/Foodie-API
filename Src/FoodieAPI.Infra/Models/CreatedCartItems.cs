namespace FoodieAPI.Infra.Models;

public class CreatedCartItems(
  Guid id,
  Guid cartId,
  string name,
  int quantity,
  decimal value,
  string avatar)
{
  public string Avatar = avatar;
  public Guid CartId = cartId;
  public Guid Id = id;
  public string Name = name;
  public int Quantity = quantity;
  public decimal Value = value;
}