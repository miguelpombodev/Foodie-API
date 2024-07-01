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

    [HttpGet("")]
    public async Task<IActionResult> GetStoresListAsync()
    {
      var storeList = await _service.GetStoreListAsync();

      return StatusCode(
        StatusCodes.Status200OK,
        storeList
      );
    }

    [HttpGet("/categories")]
    public async Task<IActionResult> GetStoreCategoriesList()
    {
      var storeCategoriesList = await _service.GetStoreCategoriesListAsync();

      return StatusCode(
        StatusCodes.Status200OK,
        storeCategoriesList
      );
    }

    [HttpGet("/types")]
    public async Task<IActionResult> GetStoreCategoriesTypes()
    {
      var storeTypesList = await _service.GetStoreCategoriesTypesListAsync();

      return StatusCode(
        StatusCodes.Status200OK,
        storeTypesList
      );
    }
  }
}