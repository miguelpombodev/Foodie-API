using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Services;

public interface IMiscelaneousService
{
    Task<List<BannerMongoEntity>> GetAllBannersAsync();
    Task<string> CreateOneBannerAsync(CreateBannerDto banner);
}