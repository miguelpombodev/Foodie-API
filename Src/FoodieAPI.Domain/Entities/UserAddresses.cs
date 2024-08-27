namespace FoodieAPI.Domain.Entities;

public class UserAddresses(
    Guid userId,
    string address,
    string number,
    string addressComplement,
    bool isDefault,
    DateTime createdAt,
    DateTime updatedAt)
    : BaseEntity
{
    public Guid UserId { get; set; } = userId;
    public string Address { get; set; } = address;
    public string Number { get; set; } = number;
    public string AddressComplement { get; set; } = addressComplement;
    public bool IsDefault { get; set; } = isDefault;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime UpdatedAt { get; set; } = updatedAt;
}