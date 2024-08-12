using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FoodieAPI.Domain.Entities;
using FoodieAPI.Infra.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FoodieAPI.Services;

public static class TokenService
{
  public static string GenerateToken(User user)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(AppConfiguration.JWTKey);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(
            new Claim[] { new Claim(ClaimTypes.MobilePhone, user.Phone) }
        ),
      Expires = DateTime.UtcNow.AddHours(8),
      SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
        )
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }

  public static string GenerateToken(IEnumerable<Claim> claims)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(AppConfiguration.JWTKey);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.UtcNow.AddHours(3),
      SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
        )
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }

  public static string DecodeToken(string token)
  {
    var tokenHandler = new JwtSecurityTokenHandler();

    var splittedToken = token.Split(" ").First(c => c != "Bearer");

    var decodedToken = tokenHandler.ReadToken(splittedToken);

    var tokenInfo = decodedToken as JwtSecurityToken;
    return tokenInfo.Claims.First(claim => claim.Type == ClaimTypes.MobilePhone).Value;

  }

  public static string GenerateRefreshToken()
  {
    var randomNumber = new Guid().ToByteArray();
    using var rng = RandomNumberGenerator.Create();
    rng.GetBytes(randomNumber);
    return Convert.ToBase64String(randomNumber);
  }

  public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
  {
    var tokenValidationParameters = new TokenValidationParameters
    {
      ValidateAudience = false,
      ValidateIssuer = false,
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfiguration.JWTKey)),
      ValidateLifetime = false,
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
    if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
      StringComparison.InvariantCultureIgnoreCase
    )) throw new SecurityTokenException("Invalid Token");

    return principal;
  }

  private static List<(string, string)> _refreshTokensList = new();
  public static void SaveRefreshToken(string userPhone, string refreshToken)
  {
    _refreshTokensList.Add(new(userPhone, refreshToken));
  }

  public static string GetRefreshToken(string userPhone)
  {
    return _refreshTokensList.FirstOrDefault(x => x.Item1 == userPhone).Item2;
  }

  public static void DeleteRefreshToken(string userPhone, string refreshToken)
  {
    var item = _refreshTokensList.FirstOrDefault(x => x.Item1 == userPhone && x.Item2 == refreshToken);
    _refreshTokensList.Remove(item);
  }
}
