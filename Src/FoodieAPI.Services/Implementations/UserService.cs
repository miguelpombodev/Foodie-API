using FoodieAPI.Domain;
using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Domain.Interfaces.Services;

namespace FoodieAPI.Services.Implementations
{
  public class UserService(IUserRepository userRepository) : IUserService
  {
    private readonly IUserRepository _repository = userRepository;

    async public Task<string> CreateOneUserAsync(CreateUserDTO body)
    {
      var user = await _repository.GetByEmailAsync(body.Email);

      if (user != null)
      {
        throw new IndexOutOfRangeException("Something went wrong with user's email/phone, please be sure");
      }

      User formattingUserToDB = new(
        body.Name,
        body.Phone,
        body.Email,
        body.CPF,
        DateTime.Now.ToUniversalTime(),
        DateTime.Now.ToUniversalTime()
      );

      await _repository.SaveAsync(formattingUserToDB);

      return "success";
    }

    public Task<string> DeleteOneUserAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<List<User>> GetUsersListAsync()
    {
      var UsersList = await _repository.GetUserListAsync();

      return UsersList;
    }

    public Task<string> UpdateOneUserAsync()
    {
      throw new NotImplementedException();
    }
  }
}