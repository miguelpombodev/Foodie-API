using FoodieAPI.Domain;
using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Interfaces.Services;
using FoodieAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FoodieAPI.Web.Controllers
{
  [Route("account")]
  [ApiController]
  public class UserController(IUserService userService, IDataEncryptionService encryptionService) : ControllerBase
  {
    private readonly IDataEncryptionService _encryptionService = encryptionService;
    private readonly IUserService _service = userService;

    [HttpPost("v1/create")]
    public async Task<IActionResult> CreateOneUserAsync(
      [FromBody] CreateUserDTO body
    )
    {
      body.CPF = _encryptionService.Hash(body.CPF);

      var result = await _service.CreateOneUserAsync(
        body
      );

      return StatusCode(
        StatusCodes.Status200OK, new { result }
      );
    }

    [HttpPost("v1/login")]
    public async Task<IActionResult> AuthenticateAsync(
      [FromBody] AuthenticateUserDTO body
    )
    {
      var user = await _service.GetOneUserAsync(body.Email);

      var token = TokenService.GenerateToken(user);
      var refreshToken = TokenService.GenerateRefreshToken();
      TokenService.SaveRefreshToken(user.Phone, refreshToken);

      return StatusCode(
        StatusCodes.Status200OK, new
        {
          token = token,
          refreshToken = refreshToken
        }
      );
    }

    [HttpPost("v1/refresh")]
    [Authorize]
    public IActionResult Refresh(
      [FromHeader] string authorization,
      [FromHeader] string refreshToken
    )
    {
      if (string.IsNullOrEmpty(authorization) && string.IsNullOrEmpty(refreshToken))
      {
        return StatusCode(
          StatusCodes.Status400BadRequest,
          new { detail = "JWT Token or Refresh Token is missing" }
        );
      };

      var principal = TokenService.GetPrincipalFromExpiredToken(authorization);
      var userPhone = principal.Identity.Name;
      var savedRefreshToken = TokenService.GetRefreshToken(userPhone);
      if (savedRefreshToken != refreshToken)
        throw new SecurityTokenException("Invalid Refresh Token!");

      var newJwtToken = TokenService.GenerateToken(principal.Claims);
      var newRefreshToken = TokenService.GenerateRefreshToken();
      TokenService.DeleteRefreshToken(userPhone, refreshToken);
      TokenService.SaveRefreshToken(userPhone, newRefreshToken);

      return StatusCode(
        StatusCodes.Status200OK, new
        {
          token = newJwtToken,
          refreshToken = newRefreshToken
        }
      );
    }

    [HttpGet("v1/list")]
    public async Task<IActionResult> GetUsersListAsync()
    {
      var usersList = await _service.GetUsersListAsync();

      return StatusCode(
        StatusCodes.Status200OK, new { usersList }
      );
    }
  }
}