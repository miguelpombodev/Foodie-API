using FoodieAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodieAPI.Web.Controllers
{
  [Route("store")]
  [ApiController]
  [Authorize]
  public class StoreController : ControllerBase
  {
    private readonly IStoreService _service;

    public StoreController(IStoreService storeService)
    {
      _service = storeService;
    }

    [HttpGet("v1/", Name = "Get List of Stores")]
    public async Task<IActionResult> GetStoresListAsync()
    {
      var storeList = await _service.GetStoreListAsync();

      return StatusCode(
        StatusCodes.Status200OK,
        storeList
      );
    }

    [HttpGet("v1/categories", Name = "Get List of Stores Categories")]
    public async Task<IActionResult> GetStoreCategoriesList()
    {
      var storeCategoriesList = await _service.GetStoreCategoriesListAsync();

      return StatusCode(
        StatusCodes.Status200OK,
        storeCategoriesList
      );
    }

    [HttpGet("v1/types", Name = "Get List of Stores Categories Types")]
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