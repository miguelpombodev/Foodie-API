namespace FoodieAPI.Domain.Entities;

public class CartItem(
  Guid cartId,
  Guid productId,
  int productAmount,
  DateTime createdAt,
  DateTime updatedAt)
  : BaseEntity
{
  public Guid CartId { get; set; } = cartId;
  public Guid ProductId { get; set; } = productId;
  public int ProductAmount { get; set; } = productAmount;
  public DateTime CreatedAt { get; set; } = createdAt;
  public DateTime UpdatedAt { get; set; } = updatedAt;
  public Cart Cart { get; set; }
}