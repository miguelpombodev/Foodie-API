using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Services
{
  public interface IUserService
  {
    Task<List<User>> GetUsersListAsync();
  }
}