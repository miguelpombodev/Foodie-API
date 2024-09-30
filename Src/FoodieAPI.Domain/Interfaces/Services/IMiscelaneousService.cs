using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.DTO.Services;
using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Services;

public interface IMiscelaneousService
{
    Task<List<BannerMongoEntity>> GetAllBannersAsync();
    Task<string> CreateOneBannerAsync(CreateBannerDto banner);
    Task<string> CreateOneEmailTemplateAsync(CreateEmailTemplateDto emailTemplateBody);
    Task<EmailTemplateMongoEntity> GetOneEmailTemplateAsync(string emailTemplateName);
}