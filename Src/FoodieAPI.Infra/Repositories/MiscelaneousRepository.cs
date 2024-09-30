using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.DTO.Services;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Infra.Context;
using MongoDB.Driver;

namespace FoodieAPI.Infra.Repositories;

public class MiscelaneousRepository(MongoConfiguration configuration) : IMiscelaneousRepository
{
    private readonly IMongoCollection<BannerMongoEntity> _bannerCollection = configuration.GetCollection<BannerMongoEntity>("Banners");
    private readonly IMongoCollection<EmailTemplateMongoEntity> _emailsTemplatesCollection = configuration.GetCollection<EmailTemplateMongoEntity>("EmailsTemplates");
    
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
    
    public async Task<bool> CreateOneEmailTemplateAsync(CreateEmailTemplateDto emailTemplate)
    {
        var emailTemplateEntity = new EmailTemplateMongoEntity(emailTemplate.EmailTemplateName, emailTemplate.EmailTemplateContent);
        await _emailsTemplatesCollection.InsertOneAsync(emailTemplateEntity);

        return true;
    }
    
    public async Task<EmailTemplateMongoEntity> GetOneEmailContentByNameAsync(string emailTemplateName)
    {
        var emailTemplate = await _emailsTemplatesCollection.Find(x => x.EmailTemplateName == emailTemplateName).FirstOrDefaultAsync();

        return emailTemplate;
    }
}