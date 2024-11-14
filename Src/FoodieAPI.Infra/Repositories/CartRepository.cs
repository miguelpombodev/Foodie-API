using FoodieAPI.Domain.Entities;
using FoodieAPI.Infra.Context;
using FoodieAPI.Infra.Interfaces;
using FoodieAPI.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodieAPI.Infra.Repositories;

public class CartRepository(DataContext dataContext) : ICartRepository
{
  private readonly DbSet<Cart> _carts = dataContext.Set<Cart>();
  private readonly DbSet<CartItem> _cartsItems = dataContext.Set<CartItem>();


  public async Task<Cart?> GetCartByIdAsync(Guid cartId)
  {
    var cart = await _carts.FirstOrDefaultAsync(x => x.Id == cartId);

    return cart;
  }


  public async Task<List<CreatedCartItems>> GetCartItemsByCartIdAsync(Guid cartId)
  {
    var cartItemsJoinProducts = _cartsItems.Join(
      dataContext.Set<Product>(),
      cartItem => cartItem.ProductId,
      product => product.Id,
      (cartItem, product) => new
      {
        cartItemId = cartItem.Id,
        cartItemCartId = cartItem.CartId,
        cartItemName = product.Name,
        cartItemProductAmount = cartItem.ProductAmount,
        cartItemValue = product.Value,
        cartItemAvatar = product.Avatar
      }
    );

    var cartItems = await cartItemsJoinProducts.Where(query => query.cartItemCartId == cartId)
      .Select(query =>
        new CreatedCartItems(
          query.cartItemId,
          query.cartItemCartId,
          query.cartItemName,
          query.cartItemProductAmount,
          query.cartItemValue,
          query.cartItemAvatar
        )).ToListAsync();

    return cartItems;
  }


  public async Task<Cart?> GetLastCreatedCart()
  {
    var cart = await _carts.OrderByDescending(cart => cart.CreatedAt).FirstOrDefaultAsync();

    return cart;
  }


  public async Task<Cart> SaveCartAsync(Cart cart)
  {
    await dataContext.Set<Cart>().AddAsync(cart);
    await dataContext.SaveChangesAsync();

    return cart;
  }


  public async Task<IList<CartItem>> SaveCartItemsAsync(IList<CartItem> cartItems)
  {
    await dataContext.Set<CartItem>().AddRangeAsync(cartItems);
    await dataContext.SaveChangesAsync();

    return cartItems;
  }
}