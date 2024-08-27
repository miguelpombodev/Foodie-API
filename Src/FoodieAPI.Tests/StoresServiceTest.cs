using FoodieAPI.Domain.DTO.Responses;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Services.Implementations;
using Moq;

namespace FoodieAPI.Tests;

public class StoresServiceTest
{
    private readonly Mock<IStoreRepository> _mockStoreRepository = new();
    
    [Fact(DisplayName = "Should return a list stores")]
    public async void ShouldReturnListOfStoresWithoutAnyFilter()
    {
        //Arrange
        var repositoryReturn = new List<ListStoreResponseDto>()
        {
            new (
                    storeTypeName: "Store Type Teste",
                    storeName: "Store Name Teste",
                    storeRate: decimal.Parse("5.0"),
                    storeAvatar: "image.png",
                    storeMinDeliveryTime: "30",
                    storeMaxDeliveryTime: "60",
                    storeDeliveryFee: decimal.Parse("0.0")
                ),
            new (
                    storeTypeName: "Store Type Teste",
                    storeName: "Store Name Teste",
                    storeRate: decimal.Parse("5.0"),
                    storeAvatar: "image.png",
                    storeMinDeliveryTime: "30",
                    storeMaxDeliveryTime: "60",
                    storeDeliveryFee: decimal.Parse("0.0")
            ),
            new (
                    storeTypeName: "Store Type Teste",
                    storeName: "Store Name Teste",
                    storeRate: decimal.Parse("5.0"),
                    storeAvatar: "image.png",
                    storeMinDeliveryTime: "30",
                    storeMaxDeliveryTime: "60",
                    storeDeliveryFee: decimal.Parse("0.0")
            )
        };
        
        _mockStoreRepository.Setup( test => test.GetStoreListAsync(null, null)).ReturnsAsync(repositoryReturn);
        var mockStoreService = new StoreService(_mockStoreRepository.Object);
        
        //Act
        var result = await mockStoreService.GetStoreListAsync(null, null);
        
        //Assert
        Assert.Equal(repositoryReturn, result);
    }
}