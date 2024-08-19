using FoodieAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodieAPI.Web.Controllers
{
  [Route("products")]
  [ApiController]
  [Authorize]
  public class ProductsController(IProductsService service) : ControllerBase
  {
    [HttpGet("v1/customs/{storeTypeName}", Name = "Get Briefed List of Stores")]
    [SwaggerOperation(Summary = "Get List of Stores with briefed informations")]
    public async Task<IActionResult> GetUserCustomizedProductsListAsync(
      string storeTypeName,
      [FromQuery] string? categoryTitle
    )
    {
      var products = await service.GetUserCustomsProductsListAsync(storeTypeName, categoryTitle);

      return StatusCode(
        StatusCodes.Status200OK,
        products
      );
    }
  }
}