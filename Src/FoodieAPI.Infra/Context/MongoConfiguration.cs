using FoodieAPI.Domain.Entities;
using FoodieAPI.Infra.Configuration;
using MongoDB.Driver;

namespace FoodieAPI.Infra.Context;

public class MongoConfiguration
{
    public readonly IMongoCollection<BannerMongoEntity> _bannerCollection;
    
    public MongoConfiguration()
    {
        var mongoClient = new MongoClient($"mongodb://{AppConfiguration.MongoSettings.MongoUser}:{AppConfiguration.MongoSettings.MongoPassword}@{AppConfiguration.MongoSettings.MongoHost}:{AppConfiguration.MongoSettings.MongoPort}");
        var database = mongoClient.GetDatabase(AppConfiguration.MongoSettings.DatabaseName);
        _bannerCollection = database.GetCollection<BannerMongoEntity>(AppConfiguration.MongoSettings.CollectionName);
    }
}