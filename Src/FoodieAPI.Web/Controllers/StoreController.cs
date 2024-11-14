using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.DTO.Responses;
using FoodieAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodieAPI.Web.Controllers;

[Route("store")]
[ApiController]
[Authorize]
public class StoreController(IStoreService storeService, ICacheService cacheService)
  : ControllerBase
{
  [HttpGet("v1/", Name = "Get List of Stores")]
  [SwaggerOperation(Summary = "Gets a List of Stores")]
  public async Task<IActionResult> GetStoresListAsync(
    [FromQuery] string? sortByOptionName,
    [FromQuery] decimal? sortByDeliveryFee
  )
  {
    var storeListCached = cacheService.GetData<List<ListStoreResponseDto>>("StoreList");

    if ( storeListCached is not null )
      return StatusCode(
        StatusCodes.Status200OK,
        storeListCached
      );

    var storeList = await storeService.GetStoreListAsync(
      sortByOptionName,
      sortByDeliveryFee
    );

    cacheService.SetData("StoreList", storeList);

    return StatusCode(
      StatusCodes.Status200OK,
      new
      {
        result = storeList
      }
    );
  }


  [HttpGet("v1/categories", Name = "Get List of Stores Categories")]
  [SwaggerOperation(Summary = "Get a List of Stores Categories.")]
  public async Task<IActionResult> GetStoreCategoriesList()
  {
    var storeCategoriesList = await storeService.GetStoreCategoriesListAsync();

    return StatusCode(
      StatusCodes.Status200OK,
      new
      {
        result = storeCategoriesList
      }
    );
  }


  [HttpGet("v1/types", Name = "Get List of Stores Categories Types")]
  [SwaggerOperation(Summary = "Get a List of Stores Categories Types.")]
  public async Task<IActionResult> GetStoreCategoriesTypes(
    [FromQuery] AvatarImageType body
  )
  {
    var storeTypesList = await storeService.GetStoreCategoriesTypesListAsync(body);

    return StatusCode(
      StatusCodes.Status200OK,
      new
      {
        result = storeTypesList
      }
    );
  }
}