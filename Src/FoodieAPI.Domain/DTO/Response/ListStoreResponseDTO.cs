namespace FoodieAPI.Domain.DTO.Responses
{
  public class ListStoreResponseDTO
  {
    public ListStoreResponseDTO(string storeAvatar, string storeName, string storeTypeName, decimal storeRate)
    {
      this.StoreAvatar = storeAvatar;
      this.StoreName = storeName;
      this.StoreTypeName = storeTypeName;
      this.StoreRate = storeRate;
    }

    public string StoreAvatar;
    public string StoreName;
    public string StoreTypeName;
    public decimal StoreRate;
  }
}