using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Domain.Interfaces.Repositories;
using FoodieAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodieAPI.Infra.Repositories
{
  public class UsersRepository : IUserRepository
  {
    protected readonly DataContext _DataContext;

    public UsersRepository(DataContext dataContext)
    {
      _DataContext = dataContext;
    }

    async public Task<User?> GetByEmailAsync(string email)
    {
      var userByEmail = await _DataContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);

      return userByEmail;
    }

    async public Task<User> GetByIdAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    async public Task<User?> GetByPhoneAsync(string phone)
    {
      var userByEmail = await _DataContext.Set<User>().FirstOrDefaultAsync(x => x.Phone == phone);

      return userByEmail;
    }

    async public Task<List<User>> GetUserListAsync()
    {
      var usersList = await _DataContext.Set<User>().ToListAsync();

      return usersList;
    }

    public async Task<User> SaveAsync(User user)
    {
      await _DataContext.Set<User>().AddAsync(user);
      await _DataContext.SaveChangesAsync();

      return user;
    }

    async public Task<User> UpdateAsync(User customer)
    {
      throw new NotImplementedException();
    }
  }
}