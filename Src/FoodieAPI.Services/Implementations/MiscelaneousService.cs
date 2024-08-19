using FoodieAPI.Domain.DTO.Requests;
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
}