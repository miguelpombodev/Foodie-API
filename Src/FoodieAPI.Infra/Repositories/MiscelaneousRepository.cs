using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Infra.Context;
using MongoDB.Driver;

namespace FoodieAPI.Infra.Repositories;

public class MiscelaneousRepository(MongoConfiguration configuration) : IMiscelaneousRepository
{
    private readonly IMongoCollection<BannerMongoEntity> _bannerCollection = configuration.GetCollection<BannerMongoEntity>("Banners");

    public async Task<List<BannerMongoEntity>> GetAllBannersAsync()
    {
        var bannersList = await _bannerCollection.Find(FilterDefinition<BannerMongoEntity>.Empty).ToListAsync();

        return bannersList;
    }

    public async Task<bool> CreateOneBannerAsync(CreateBannerDto banner)
    {
        var bannerEntity = new BannerMongoEntity(banner.BannerName, banner.BannerUrl);
        await _bannerCollection.InsertOneAsync(bannerEntity);

        return true;
    }
}