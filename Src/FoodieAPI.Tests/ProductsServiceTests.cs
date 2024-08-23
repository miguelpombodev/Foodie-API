using FoodieAPI.Domain.DTO.Response;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Domain.Interfaces.Services;
using FoodieAPI.Services.Implementations;
using Moq;

namespace FoodieAPI.Tests;

public class ProductsServiceTests
{
    private readonly Mock<IProductRepository> _mockProductRepository = new();

    [Fact(DisplayName = "Should return a user custom products list")]    
    public async void ShouldReturnAUserCustomProductsList()
    {
        //Arrange
        var repositoryReturn = new List<CustomUserProductResponseDto>()
        {
            new ("image.png", "Produto Teste 1", decimal.Parse("21.00"), "loja_imagem.png", "loja_test"),
            new ("image.png", "Produto Teste 1", decimal.Parse("21.00"), "loja_imagem.png", "loja_test")
        };
        
        _mockProductRepository.Setup(x => x.GetUserCustomsProductsListAsync("typeName", null)).ReturnsAsync(repositoryReturn).Verifiable();
        var mockProductsService = new ProductService(_mockProductRepository.Object);
        
        //Act
        var result = await mockProductsService.GetUserCustomsProductsListAsync("typeName", null);
        
        //Assert
        Assert.Equal(repositoryReturn, result);
        
    }
    
    [Fact(DisplayName = "Should verify type user custom products repository method")]    
    public async void ShouldVerifyTypeOfGetUserCustomProductsMethod()
    {
        //Arrange
        var repositoryReturn = new List<CustomUserProductResponseDto>()
        {
            new ("image.png", "Produto Teste 1", decimal.Parse("21.00"), "loja_imagem.png", "loja_test"),
            new ("image.png", "Produto Teste 1", decimal.Parse("21.00"), "loja_imagem.png", "loja_test")
        };
        
        _mockProductRepository.Setup(x => x.GetUserCustomsProductsListAsync("typeName", null)).ReturnsAsync(repositoryReturn).Verifiable();
        var mockProductsService = new ProductService(_mockProductRepository.Object);
        
        //Act
        var result = await mockProductsService.GetUserCustomsProductsListAsync("typeName", null);
        
        //Assert
        Assert.IsType<List<CustomUserProductResponseDto>>(result);
        
    }
}