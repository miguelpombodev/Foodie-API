using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Repositories
{
  public interface IUserRepository
  {
    Task<List<User>> GetUserListAsync();

    Task<User> GetByIdAsync(Guid id);
    Task<User> GetByEmailAsync(string email);

    // Task<User> SaveAsync(CreateUserDTO User);
    Task<User> UpdateAsync(User customer);
  }
}