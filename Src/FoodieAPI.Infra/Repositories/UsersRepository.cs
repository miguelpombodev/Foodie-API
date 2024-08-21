using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodieAPI.Infra.Repositories
{
  public class UsersRepository(DataContext dataContext) : IUserRepository
  {
    private readonly DataContext _dataContext = dataContext;

    public async Task<User?> GetByEmailAsync(string email)
    {
      var userByEmail = await _dataContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);

      return userByEmail;
    }

    async public Task<User> GetByIdAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public async Task<User?> GetByPhoneAsync(string phone)
    {
      var userByEmail = await _dataContext.Set<User>().FirstOrDefaultAsync(x => x.Phone == phone);

      return userByEmail;
    }

    public async Task<List<User>> GetUserListAsync()
    {
      var usersList = await _dataContext.Set<User>().ToListAsync();

      return usersList;
    }

    public async Task<User> SaveAsync(User user)
    {
      await _dataContext.Set<User>().AddAsync(user);
      await _dataContext.SaveChangesAsync();

      return user;
    }

    async public Task<User> UpdateAsync(User customer)
    {
      throw new NotImplementedException();
    }
  }
}