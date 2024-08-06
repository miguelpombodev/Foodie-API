using FoodieAPI.Domain;
using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Interfaces.Services;
using FoodieAPI.Services;
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
      body.Phone = _encryptionService.Hash(body.Phone);

      var result = await _service.CreateOneUserAsync(
        body
      );

      return StatusCode(
        StatusCodes.Status200OK, new { result }
      );
    }

    [HttpPost("v1/login")]
    public async Task<IActionResult> Authenticate(
      [FromBody] string userEmail
    )
    {
      var user = await _service.GetOneUserAsync(userEmail);

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
    public async Task<IActionResult> Refresh(
      [FromBody] string token,
      [FromBody] string refreshToken
    )
    {
      var principal = TokenService.GetPrincipalFromExpiredToken(token);
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