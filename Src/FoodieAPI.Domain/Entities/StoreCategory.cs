namespace FoodieAPI.Domain.Entities
{
  public class StoreCategory : BaseEntity
  {
    public StoreCategory(string title, string storeId)
    {
      Title = title;
      StoreId = storeId;
    }
    public string Title { get; set; }
    public string StoreId { get; set; }
    public Store Store { get; set; }
  }
}