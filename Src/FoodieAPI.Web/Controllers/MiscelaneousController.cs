using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodieAPI.Web.Controllers;

[Route("documents")]
[ApiController]
public class MiscelaneousController(IMiscelaneousService service)
  : ControllerBase
{
  private readonly IMiscelaneousService _service = service;


  [HttpGet("v1/banners/get")]
  [SwaggerOperation(Summary = "Get List of Banners")]
  public async Task<ActionResult<List<BannerMongoEntity>>> GetBannersAsync()
  {
    var bannerLists = await _service.GetAllBannersAsync();
    return StatusCode(
      StatusCodes.Status200OK,
      new
      {
        result = new
        {
          Banners = bannerLists
        }
      }
    );
  }


  [HttpPost("v1/banners/create")]
  [SwaggerOperation(Summary = "Create a new Banner")]
  public async Task<ActionResult<string>> CreateOneBannerAsync
  (
    [FromBody] CreateBannerDto body
  )
  {
    var bannerEntityResult = await _service.CreateOneBannerAsync(body);

    return StatusCode(
      StatusCodes.Status200OK,
      new
      {
        result = "Banner created successfully"
      }
    );
  }


  [HttpPost("v1/email/create")]
  [SwaggerOperation(Summary = "Create a new Email Template")]
  public async Task<ActionResult<string>> CreateOneEmailTemplateAsync
  (
    [FromBody] CreateEmailTemplateDto body
  )
  {
    var emailTemplateEntityResult = await _service.CreateOneEmailTemplateAsync(body);

    return StatusCode(
      StatusCodes.Status200OK,
      new
      {
        result = "Email Template created successfully"
      }
    );
  }
}