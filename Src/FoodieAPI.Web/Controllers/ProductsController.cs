using FoodieAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

    [HttpGet("v1/customs/{storeTypeName}", Name = "Get Briefed List of Stores")]
    [SwaggerOperation(Summary = "Get List of Stores with briefed informations")]
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