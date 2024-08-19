namespace FoodieAPI.Domain.DTO.Response
{
    public class CustomUserProductResponseDto(
        string productAvatar,
        string productName,
        decimal productPrice,
        string productStoreAvatar,
        string productStoreName)
    {
        public string ProductAvatar { get; set; } = productAvatar;
        public string ProductName { get; set; } = productName;
        public decimal ProductPrice { get; set; } = productPrice;
        public string ProductStoreAvatar { get; set; } = productStoreAvatar;
        public string ProductStoreName { get; set; } = productStoreName;
    }
}