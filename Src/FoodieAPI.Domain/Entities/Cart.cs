namespace FoodieAPI.Domain.Entities;

public class Cart(
  Guid userId,
  Guid storeId,
  DateTime createdAt,
  DateTime updatedAt)
  : BaseEntity
{
  public Guid UserId { get; set; } = userId;
  public Guid StoreId { get; set; } = storeId;
  public DateTime CreatedAt { get; set; } = createdAt;
  public DateTime UpdatedAt { get; set; } = updatedAt;
  public Orders Order { get; set; }
  public IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();
  public User User { get; set; }
  public Store Store { get; set; }
}