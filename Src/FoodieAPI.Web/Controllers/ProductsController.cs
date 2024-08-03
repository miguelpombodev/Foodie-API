using FoodieAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FoodieAPI.Web.Controllers
{
  [Route("products")]
  [ApiController]
  public class ProductsController : ControllerBase
  {

    private readonly IProductsService _service;

    public ProductsController(IProductsService service)
    {
      _service = service;
    }

    [HttpGet("v1/customs/{storeTypeName}")]
    public async Task<IActionResult> GetUserCustomizedProductsListAsync(
      string storeTypeName,
      [FromQuery] string? categoryTitle
    )
    {
      var products = await _service.GetUserCustomsProductsListAsync(storeTypeName, categoryTitle);

      return StatusCode(
        StatusCodes.Status200OK,
        products
      );
    }
  }
}