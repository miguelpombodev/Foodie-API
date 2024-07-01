using FoodieAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodieAPI.Web.Controllers
{
  [Route("v1/store")]
  [ApiController]
  public class StoreController : ControllerBase
  {
    private readonly IStoreService _service;

    public StoreController(IStoreService storeService)
    {
      _service = storeService;
    }

    [HttpGet("/categories")]
    public async Task<IActionResult> GetStoreCategoriesList()
    {
      var storeCateoriesList = await _service.GetStoreCategoriesListAsync();

      return StatusCode(
        StatusCodes.Status200OK,
        storeCateoriesList
      );
    }
  }
}