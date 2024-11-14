using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Infra.Interfaces;
using FoodieAPI.Services.Interfaces;
using FoodieAPI.Services.Models;

namespace FoodieAPI.Services.Implementations;

public class CartService(ICartRepository cartRepository) : ICartService
{
  public async Task<CreatedCartWithItemModels?>? GetCartAsyncById(Guid cartId)
  {
    var createdCart = await cartRepository.GetCartByIdAsync(cartId);

    if ( createdCart == null ) return null;

    var cartItems = await cartRepository.GetCartItemsByCartIdAsync(cartId);

    return new CreatedCartWithItemModels(
      createdCart.StoreId,
      createdCart.Id,
      cartItems
    );
  }


  public async Task<CreatedCartModel?>? GetLastCreatedCartAsync()
  {
    var createCart = await cartRepository.GetLastCreatedCart();

    if ( createCart == null ) return null;

    return new CreatedCartModel(
      createCart.StoreId,
      createCart.Id
    );
  }


  public async Task<bool> CreateCart(CreateCartDto cartDto, Guid userId)
  {
    var cartEntity = new Cart(
      userId,
      cartDto.StoreId,
      DateTime.Now.ToUniversalTime(),
      DateTime.Now.ToUniversalTime()
    );

    await cartRepository.SaveCartAsync(cartEntity);

    return true;
  }


  public async Task<bool> CreateCartItems(IEnumerable<CartProducts> cartItems, Guid cartId)
  {
    IList<CartItem> cartItemsList = cartItems.Select(cartItem => new CartItem(cartId,
      cartItem.ProductId, cartItem.ProductQuantity, DateTime.Now.ToUniversalTime(),
      DateTime.Now.ToUniversalTime())).ToList();

    await cartRepository.SaveCartItemsAsync(cartItemsList);

    return true;
  }
}