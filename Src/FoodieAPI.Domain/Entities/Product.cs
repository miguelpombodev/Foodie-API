namespace FoodieAPI.Domain.Entities
{
  public class Product : BaseEntity
  {
    public string Name { get; set; }
    public decimal Value { get; set; }
    public string StoreId { get; set; }
    public string Description { get; set; }
    public string StoreCategoryId { get; set; }
    public string? Weight { get; set; }
    public int? PeopleServed { get; set; }
    public DateTime CreatedAt { get; set; }
    public StoreCategory StoreCategory { get; set; }
  }
}