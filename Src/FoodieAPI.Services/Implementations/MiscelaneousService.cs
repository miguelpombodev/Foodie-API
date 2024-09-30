using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.DTO.Services;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Domain.Interfaces.Services;

namespace FoodieAPI.Services.Implementations;

public class MiscelaneousService(IMiscelaneousRepository repository) : IMiscelaneousService
{
    private readonly IMiscelaneousRepository _repository = repository;

    public async Task<List<BannerMongoEntity>> GetAllBannersAsync()
    {
        var bannerLists =  await _repository.GetAllBannersAsync();

        return bannerLists;
    }

    public async Task<string> CreateOneBannerAsync(CreateBannerDto bannerBody)
    {
        var bannerEntityResult = await _repository.CreateOneBannerAsync(bannerBody);

        return bannerEntityResult ? "Banner created successfully": "Something went wrong while creating the banner";
    }
    
    public async Task<string> CreateOneEmailTemplateAsync(CreateEmailTemplateDto emailTemplateBody)
    {
        var bannerEntityResult = await _repository.CreateOneEmailTemplateAsync(emailTemplateBody);

        return bannerEntityResult ? "Email Template created successfully": "Something went wrong while creating the email template";
    }
    
    public async Task<EmailTemplateMongoEntity> GetOneEmailTemplateAsync(string emailTemplateName)
    {
        var emailTemplateEntityResult = await _repository.GetOneEmailContentByNameAsync(emailTemplateName);

        return emailTemplateEntityResult;
    }
}