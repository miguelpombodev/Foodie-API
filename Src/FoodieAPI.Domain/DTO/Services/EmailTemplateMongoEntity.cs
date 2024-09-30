using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodieAPI.Domain.DTO.Services;

public class EmailTemplateMongoEntity(string emailTemplateName, string emailTemplateContent)
{
    [BsonId]
    [BsonElement("_id")]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

    [BsonElement("email_template_name"), BsonRepresentation(BsonType.String)]
    public string EmailTemplateName { get; set; } = emailTemplateName;
    
    [BsonElement("email_template_content"), BsonRepresentation(BsonType.String)]
    public string EmailTemplateContent { get; set; } = emailTemplateContent;
}