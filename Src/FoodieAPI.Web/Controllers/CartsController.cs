using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Interfaces.Services;
using FoodieAPI.Services;
using FoodieAPI.Services.Interfaces;
using FoodieAPI.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodieAPI.Web.Controllers;

[Route("cart")]
[ApiController]
public class CartsController(
  ICartService cartService,
  IUserService userService,
  ICacheService cacheService) : ControllerBase
{
  [HttpPost("/create")]
  [SwaggerOperation(Summary = "Creates a new cart with a list of items and its quantity.")]
  public async Task<IActionResult> CreateCart(
    [FromHeader] string authorization,
    [FromBody] CreateCartDto body
  )
  {
    if ( string.IsNullOrEmpty(authorization) )
      return StatusCode(
        StatusCodes.Status400BadRequest,
        new { detail = "JWT Token or Refresh Token is missing" }
      );

    var userPhone = TokenService.DecodeToken(authorization);

    var user = await userService.GetOneUserAsync(userPhone);

    await cartService.CreateCart(body, user.Id);

    var cart = await cartService.GetLastCreatedCartAsync();

    await cartService.CreateCartItems(body.Products, cart.CartId);

    return StatusCode(
      StatusCodes.Status201Created,
      new
      {
        result = "Cart created successfully"
      }
    );
  }


  [HttpGet("/get/{cartId}")]
  [SwaggerOperation(Summary = "Gets a cart by Id")]
  public async Task<IActionResult> GetCart(
    Guid cartId,
    [FromHeader] string authorization
  )
  {
    if ( string.IsNullOrEmpty(authorization) )
      return StatusCode(
        StatusCodes.Status400BadRequest,
        new { detail = "JWT Token or Refresh Token is missing" }
      );

    var cachedUserCart = cacheService.GetData<CreatedCartWithItemModels>($"{cartId}[cart]");

    if ( cachedUserCart is not null )
    {
      return StatusCode(
        StatusCodes.Status200OK,
        new
        {
          result = cachedUserCart
        }
      );
    }

    var userCart = await cartService.GetCartAsyncById(cartId);

    cacheService.SetData($"{cartId}[cart]", userCart);

    return StatusCode(
      StatusCodes.Status200OK,
      new
      {
        result = userCart
      }
    );
  }
}