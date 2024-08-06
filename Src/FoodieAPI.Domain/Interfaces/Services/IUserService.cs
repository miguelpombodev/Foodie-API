using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Services
{
  public interface IUserService
  {
    Task<List<User>> GetUsersListAsync();
    Task<string> CreateOneUserAsync(
      CreateUserDTO body
    );
    Task<string> UpdateOneUserAsync();
    Task<string> DeleteOneUserAsync();
  }
}