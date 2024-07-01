namespace FoodieAPI.Domain.Entities
{
  public class StoreCategory : BaseEntity
  {
    public string Title { get; set; }
    public Guid StoreId { get; set; }
    public Store Store { get; set; }
  }
}