using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Domain.Interfaces.Services;

namespace FoodieAPI.Services.Implementations
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _repository;
    public UserService(IUserRepository userRepository)
    {
      _repository = userRepository;
    }

    public async Task<List<User>> GetUsersListAsync()
    {
      var UsersList = await _repository.GetUserListAsync();

      return UsersList;
    }
  }
}