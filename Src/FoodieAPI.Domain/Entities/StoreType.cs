namespace FoodieAPI.Domain.Entities
{
  public class StoreType
  {
    public StoreType(int id, string name, DateTime createdAt, DateTime updatedAt)
    {
      Id = id;
      Name = name;
      CreatedAt = createdAt;
      UpdatedAt = updatedAt;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}