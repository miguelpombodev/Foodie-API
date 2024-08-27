namespace FoodieAPI.Domain.Entities;

public class Store(
    string name,
    string avatar,
    int storeTypeId,
    string description,
    decimal orderMinValue,
    TimeOnly openAt,
    TimeOnly closedAt,
    string address,
    string CNPJ,
    string CEP,
    string storeMinDeliveryTime,
    string storeMaxDeliveryTime,
    decimal storeDeliveryFee,
    decimal storeRate,
    DateTime createdAt,
    DateTime updatedAt)    
    : BaseEntity
{
    public string Name { get; set; } = name;
    public string Avatar { get; set; } = avatar;
    public int StoreTypeId { get; set; } = storeTypeId;
    public string Description { get; set; } = description;
    public decimal OrderMinValue { get; set; } = orderMinValue;
    public TimeOnly OpenAt { get; set; } = openAt;
    public TimeOnly ClosedAt { get; set; } = closedAt;
    public string Address { get; set; } = address;
    public string CNPJ { get; set; } = CNPJ;
    public string CEP { get; set; } = CEP;
    public string StoreMinDeliveryTime { get; set; } = storeMinDeliveryTime;
    public string StoreMaxDeliveryTime { get; set; } = storeMaxDeliveryTime;
    public decimal StoreDeliveryFee { get; set; } = storeDeliveryFee;
    public decimal StoreRate { get; set; } = storeRate;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime UpdatedAt { get; set; } = updatedAt;
    public StoreType StoreType { get; set; }
    public IList<StoreCategory> StoreCategories { get; set; }
    public IList<Product> Products { get; set; }
}