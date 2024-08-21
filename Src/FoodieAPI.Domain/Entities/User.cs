namespace FoodieAPI.Domain.Entities
{
  public class User(string name, string phone, string email, string cPF, DateTime createdAt, DateTime updatedAt) : BaseEntity
  {
    public string Name { get; set; } = name;
    public string Phone { get; set; } = phone;
    public string Email { get; set; } = email;
    public string Cpf { get; set; } = cPF;
    public DateTime CreatedAt { get; private set; } = createdAt;
    public DateTime UpdatedAt { get; private set; } = updatedAt;
  }
}