using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Repositories;

public interface IMiscelaneousRepository
{
    Task<List<BannerMongoEntity>> GetAllBannersAsync();
    Task<bool> CreateOneBannerAsync(CreateBannerDto banner);
}