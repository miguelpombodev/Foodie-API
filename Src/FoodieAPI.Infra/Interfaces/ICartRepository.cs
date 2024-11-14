using FoodieAPI.Domain.Entities;
using FoodieAPI.Infra.Models;

namespace FoodieAPI.Infra.Interfaces;

public interface ICartRepository
{
  Task<Cart?> GetCartByIdAsync(Guid cartId);
  Task<List<CreatedCartItems>> GetCartItemsByCartIdAsync(Guid cartId);
  Task<Cart?> GetLastCreatedCart();
  Task<Cart> SaveCartAsync(Cart cart);

  Task<IList<CartItem>> SaveCartItemsAsync(IList<CartItem> cartItems);
}