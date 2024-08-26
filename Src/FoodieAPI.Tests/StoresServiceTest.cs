using FoodieAPI.Domain.DTO.Responses;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Services.Implementations;
using Moq;

namespace FoodieAPI.Tests;

public class StoresServiceTest
{
    private readonly Mock<IStoreRepository> _mockStoreRepository = new();
    
    [Fact(DisplayName = "Should return a list stores")]
    public async void ShouldReturnListOfStores()
    {
        //Arrange
        var repositoryReturn = new List<ListStoreResponseDTO>()
        {
            new (
                    storeTypeName: "Store Type Teste",
                    storeName: "Store Name Teste",
                    storeRate: decimal.Parse("5.0"),
                    storeAvatar: "image.png"
                ),
            new (
                    storeTypeName: "Store Type Teste",
                    storeName: "Store Name Teste",
                    storeRate: decimal.Parse("5.0"),
                    storeAvatar: "image.png"
            ),
            new (
                    storeTypeName: "Store Type Teste",
                    storeName: "Store Name Teste",
                    storeRate: decimal.Parse("5.0"),
                    storeAvatar: "image.png"
            )
        };
        
        _mockStoreRepository.Setup( test => test.GetStoreListAsync()).ReturnsAsync(repositoryReturn);
        var mockStoreService = new StoreService(_mockStoreRepository.Object);
        
        //Act
        var result = await mockStoreService.GetStoreListAsync();
        
        //Assert
        Assert.Equal(repositoryReturn, result);
    }
}