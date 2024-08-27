namespace FoodieAPI.Domain.Entities
{
  public class User(string name, string phone, string email, string CPF, string? avatar, DateTime createdAt, DateTime updatedAt) : BaseEntity
  {
    public string Name { get; set; } = name;
    public string Phone { get; set; } = phone;
    public string Email { get; set; } = email;
    public string CPF { get; set; } = CPF;

    public string? Avatar { get; set; } = avatar;
    public DateTime CreatedAt { get; private set; } = createdAt;
    public DateTime UpdatedAt { get; private set; } = updatedAt;
  }
}