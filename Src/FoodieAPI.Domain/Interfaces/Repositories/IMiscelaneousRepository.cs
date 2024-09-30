using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.DTO.Services;
using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Repositories;

public interface IMiscelaneousRepository
{
    Task<List<BannerMongoEntity>> GetAllBannersAsync();
    Task<bool> CreateOneBannerAsync(CreateBannerDto banner);
    Task<bool> CreateOneEmailTemplateAsync(CreateEmailTemplateDto emailTemplate);
    Task<EmailTemplateMongoEntity> GetOneEmailContentByNameAsync(string emailTemplateName);
}