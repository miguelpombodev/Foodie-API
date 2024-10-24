using FoodieAPI.Domain.Entities;
using FoodieAPI.Infra.Configuration;
using MongoDB.Driver;

namespace FoodieAPI.Infra.Context;

public class MongoConfiguration
{
    private readonly IMongoDatabase _database;
    
    public MongoConfiguration()
    {
        var mongoClient = new MongoClient($"mongodb://{AppConfiguration.MongoSettings.MongoUser}:{AppConfiguration.MongoSettings.MongoPassword}@{AppConfiguration.MongoSettings.MongoHost}:{AppConfiguration.MongoSettings.MongoPort}");;
        _database = mongoClient.GetDatabase(AppConfiguration.MongoSettings.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
    
}