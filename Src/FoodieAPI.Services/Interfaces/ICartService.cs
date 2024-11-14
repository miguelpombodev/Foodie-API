using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Services.Models;

namespace FoodieAPI.Services.Interfaces;

public interface ICartService
{
  Task<CreatedCartWithItemModels?>? GetCartAsyncById(Guid cartId);
  Task<CreatedCartModel?>? GetLastCreatedCartAsync();

  Task<bool> CreateCart(CreateCartDto cart, Guid userId);
  Task<bool> CreateCartItems(IEnumerable<CartProducts> cartItems, Guid cartId);
}