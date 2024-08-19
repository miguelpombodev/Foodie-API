
using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodieAPI.Web.Controllers;

[Route("documents")]
public class MongoDocumentsController : ControllerBase
{
    private readonly IMongoCollection<BannerMongoEntity> _banners;

    public MongoDocumentsController(MongoConfiguration mongoConfiguration)
    {
        _banners = mongoConfiguration._bannerCollection;
    }

    [HttpGet("v1/banners/get")]
    [SwaggerOperation(Summary = "Get List of Banners")]
    public async Task<ActionResult<List<BannerMongoEntity>>> GetBannersAsync()
    {
        var bannerLists =  await _banners.Find(FilterDefinition<BannerMongoEntity>.Empty).ToListAsync();
        return StatusCode(
            StatusCodes.Status200OK,
            new
            {
                Banners = bannerLists
            }
        );
    }
    
    [HttpPost("v1/banners/create")]
    [SwaggerOperation(Summary = "Create a new Banner")]
    public async Task<ActionResult<List<BannerMongoEntity>>> CreateOneBannerAsync
        (
            [FromBody] CreateBannerDto body
            )
    {
        var bannerEntity = new BannerMongoEntity(body.BannerName, body.BannerUrl);
        await _banners.InsertOneAsync(bannerEntity);
        return StatusCode(
            StatusCodes.Status200OK,
            new
            {
                Details = "Banner created successfully"
            }
        );
    }
}