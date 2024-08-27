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

    public async Task<string> CreateOneUserAsync(CreateUserDto body)
    {
      var user = await _repository.GetByEmailAsync(body.Email);

      if (user != null)
      {
        throw new IndexOutOfRangeException("Something went wrong with user's email/phone, please be sure");
      }

      User formattingUserToDb = new(
        body.Name,
        body.Phone,
        body.Email,
        body.CPF,
        body.Avatar,
        DateTime.Now.ToUniversalTime(),
        DateTime.Now.ToUniversalTime()
      );

      await _repository.SaveAsync(formattingUserToDb);

      return "success";
    }

    public Task<string> DeleteOneUserAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<User> GetOneUserAsync(string userEmail)
    {
      var user = await _repository.GetByEmailAsync(userEmail) ?? throw new IndexOutOfRangeException("Something went wrong with user's email/phone, please be sure");

      return user;
    }

    public async Task<List<User>> GetUsersListAsync()
    {
      var usersList = await _repository.GetUserListAsync();

      return usersList;
    }

    public Task<string> UpdateOneUserAsync()
    {
      throw new NotImplementedException();
    }
  }
}