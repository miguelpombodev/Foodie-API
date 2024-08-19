using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodieAPI.Domain.Entities;

public class BannerMongoEntity(string bannerName, string bannerUrl)
{
    [BsonId]
    [BsonElement("_id")]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [BsonElement("banner_name"), BsonRepresentation(BsonType.String)]
    public string BannerName { get; set; } = bannerName;

    [BsonElement("banner_url"), BsonRepresentation(BsonType.String)]
    public string BannerUrl { get; set; } = bannerUrl;
}