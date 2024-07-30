namespace FoodieAPI.Domain.Entities
{
  public class Store : BaseEntity
  {
    public Store(string name, string avatar, int storeTypeId, string description, decimal orderMinValue, TimeOnly openAt, TimeOnly closedAt, string address, string cNPJ, string cEP, DateTime createdAt, DateTime updatedAt)
    {
      Name = name;
      Avatar = avatar;
      StoreTypeId = storeTypeId;
      Description = description;
      OrderMinValue = orderMinValue;
      OpenAt = openAt;
      ClosedAt = closedAt;
      Address = address;
      CNPJ = cNPJ;
      CEP = cEP;
      CreatedAt = createdAt;
      UpdatedAt = updatedAt;
    }

    public string Name { get; set; }
    public string Avatar { get; set; }
    public int StoreTypeId { get; set; }
    public string Description { get; set; }
    public decimal OrderMinValue { get; set; }
    public TimeOnly OpenAt { get; set; }
    public TimeOnly ClosedAt { get; set; }
    public string Address { get; set; }
    public string CNPJ { get; set; }
    public string CEP { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public StoreType StoreType { get; set; }
    public IList<StoreCategory> StoreCategories { get; set; }
    public IList<Product> Products { get; set; }
  }
}