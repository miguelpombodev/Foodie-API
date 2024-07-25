namespace FoodieAPI.Domain.Entities
{
  public class StoreType
  {
    public StoreType(int id, string name, string avatar, DateTime createdAt, DateTime updatedAt)
    {
      Id = id;
      Name = name;
      Avatar = avatar;
      CreatedAt = createdAt;
      UpdatedAt = updatedAt;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string? Avatar { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}