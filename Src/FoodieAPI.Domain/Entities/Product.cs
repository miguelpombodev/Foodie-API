namespace FoodieAPI.Domain.Entities
{
  public class Product : BaseEntity
  {
    public Product(string name, decimal value, Guid storeId, string description, Guid storeCategoryId, string? weight, int? peopleServed, string avatar, DateTime createdAt, DateTime updatedAt)
    {
      Name = name;
      Value = value;
      StoreId = storeId;
      Description = description;
      StoreCategoryId = storeCategoryId;
      Weight = weight;
      PeopleServed = peopleServed;
      Avatar = avatar;
      CreatedAt = createdAt;
      UpdatedAt = updatedAt;
    }

    public string Name { get; set; }
    public decimal Value { get; set; }
    public Guid StoreId { get; set; }
    public string Description { get; set; }
    public Guid StoreCategoryId { get; set; }
    public string? Weight { get; set; }
    public int? PeopleServed { get; set; }
    public string Avatar { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public StoreCategory StoreCategory { get; set; }
    public Store Store { get; set; }

  }
}