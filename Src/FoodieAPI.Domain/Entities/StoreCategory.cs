namespace FoodieAPI.Domain.Entities
{
  public class StoreCategory : BaseEntity
  {
    public StoreCategory(string title, Guid storeId, Store store)
    {
      Title = title;
      StoreId = storeId;
      Store = store;
    }

    public string Title { get; set; }
    public Guid StoreId { get; set; }
    public Store? Store { get; set; }
  }
}