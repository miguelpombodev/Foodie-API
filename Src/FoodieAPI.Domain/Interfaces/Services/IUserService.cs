using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Services
{
  public interface IUserService
  {
    Task<List<User>> GetUsersListAsync();
    Task<string> CreateOneUserAsync(
      CreateUserDto body
    );
    Task<string> UpdateOneUserAsync();
    Task<string> DeleteOneUserAsync();
    Task<User> GetOneUserAsync(AuthenticateUserDTO body);
  }
}