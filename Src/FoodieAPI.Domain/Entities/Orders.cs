namespace FoodieAPI.Domain.Entities;

public class Orders(
  Guid userId,
  Guid cartId,
  DateTime paidAt,
  DateTime completedAt,
  int paidById,
  decimal subTotalValue,
  decimal? deliveryFeeValue,
  decimal totalValue,
  Guid userAddressId,
  DateTime createdAt,
  DateTime updatedAt)
  : BaseEntity
{
  public Guid UserId { get; set; } = userId;
  public Guid CartId { get; set; } = cartId;
  public DateTime PaidAt { get; set; } = paidAt;
  public DateTime CompletedAt { get; set; } = completedAt;
  public int PaidById { get; set; } = paidById;
  public decimal SubTotalValue { get; set; } = subTotalValue;
  public decimal TotalValue { get; set; } = totalValue;
  public decimal? DeliveryFeeValue { get; set; } = deliveryFeeValue;
  public Guid UserAddressId { get; set; } = userAddressId;
  public DateTime CreatedAt { get; set; } = createdAt;
  public DateTime UpdatedAt { get; set; } = updatedAt;
  public User User { get; set; }
  public Cart Cart { get; set; }
  public UserAddresses UserAddress { get; set; }
}