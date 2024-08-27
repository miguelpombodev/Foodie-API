namespace FoodieAPI.Domain.DTO.Responses
{
  public class ListStoreResponseDTO(string storeAvatar, string storeName, string storeTypeName, decimal storeRate, string storeMinDeliveryTime, string storeMaxDeliveryTime, decimal storeDeliveryFee)
  {
    public string StoreAvatar = storeAvatar;
    public string StoreName = storeName;
    public string StoreTypeName = storeTypeName;
    public decimal StoreRate = storeRate;
    public string StoreMinDeliveryTime { get; set; } = storeMinDeliveryTime;
    public string StoreMaxDeliveryTime { get; set; } = storeMaxDeliveryTime;
    public decimal StoreDeliveryFee { get; set; } = storeDeliveryFee;
  }
}