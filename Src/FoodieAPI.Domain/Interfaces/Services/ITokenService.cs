using System.Security.Claims;
using FoodieAPI.Domain.Entities;

namespace FoodieAPI.Domain.Interfaces.Services;

public interface ITokenService
{
  string GenerateToken(User user);
  string DecodeToken(string token);
  string GenerateRefreshToken();
  ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

  void SaveRefreshToken(string userPhone, string refreshToken);

  string GetRefreshToken(string userPhone);

  void DeleteRefreshToken(string userPhone, string refreshToken);
}
