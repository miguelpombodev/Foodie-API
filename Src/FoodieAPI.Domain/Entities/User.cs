namespace FoodieAPI.Domain.Entities
{
  public class User(string name, string phone, string email, string cPF, DateTime created_At, DateTime updated_At) : BaseEntity
  {
    public string Name { get; set; } = name;
    public string Phone { get; set; } = phone;
    public string Email { get; set; } = email;
    public string CPF { get; set; } = cPF;
    public DateTime Created_At { get; private set; } = created_At;
    public DateTime Updated_At { get; private set; } = updated_At;
  }
}