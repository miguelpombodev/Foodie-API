namespace FoodieAPI.Domain.Entities
{
  public class User : BaseEntity
  {
    public User(string name, string phone, string email, string cPF, DateTime created_At, DateTime updated_At)
    {
      Name = name;
      Phone = phone;
      Email = email;
      CPF = cPF;
      Created_At = created_At;
      Updated_At = updated_At;
    }

    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public DateTime Created_At { get; private set; }
    public DateTime Updated_At { get; private set; }
  }
}