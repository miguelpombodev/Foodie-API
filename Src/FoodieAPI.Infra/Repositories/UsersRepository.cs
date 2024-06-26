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

    async public Task<User> GetByEmailAsync(string email)
    {
      throw new NotImplementedException();
    }

    async public Task<User> GetByIdAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    async public Task<List<User>> GetUserListAsync()
    {
      var usersList = await _DataContext.Set<User>().ToListAsync();

      return usersList;
    }

    // async public Task<User> SaveAsync(CreateUserDTO User)
    // {
    //   throw new NotImplementedException();
    // }

    async public Task<User> UpdateAsync(User customer)
    {
      throw new NotImplementedException();
    }
  }
}