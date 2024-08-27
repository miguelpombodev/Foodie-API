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
    private const string DefaultAvatarImageName = "default.png";

    public async Task<string> CreateOneUserAsync(CreateUserDto body)
    {
      var user = await _repository.GetByEmailAsync(body.Email);

      if (user != null)
      {
        throw new IndexOutOfRangeException("Something went wrong with user's email/phone, please be sure");
      }

      User formattingUserToDb = new(
        body.Avatar ?? DefaultAvatarImageName,
        body.Name,
        body.Phone,
        body.Email,
        body.CPF,
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

    public async Task<User> GetOneUserAsync(AuthenticateUserDTO body)
    {
      var user = body.Email != null ? await _repository.GetByEmailAsync(body.Email) : await _repository.GetByPhoneAsync(body.Phone);

      if (user == null)
        throw new IndexOutOfRangeException("Something went wrong with user's email/phone, please be sure");

      return user;
    }

    public async Task<User> GetOneUserAsync(string userPhone)
    {
      var user = await _repository.GetByPhoneAsync(userPhone);

      if (user == null)
        throw new IndexOutOfRangeException("Something went wrong with user's email/phone, please be sure");

      return user;
    }

    public Task<IList<UserAddresses>?> GetUserAddressesAsync(Guid id)
    {
      var userAddresses = _repository.GetUserAddressesAsync(id);
      
      if (userAddresses == null)
        throw new IndexOutOfRangeException("There's no user's addresses");

      return userAddresses;
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