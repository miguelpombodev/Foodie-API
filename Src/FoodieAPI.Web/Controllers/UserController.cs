using FoodieAPI.Domain;
using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Interfaces.Services;
using FoodieAPI.Services;
using FoodieAPI.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodieAPI.Web.Controllers;

[Route("account")]
[ApiController]
public class UserController(
  IUserService userService,
  IDataEncryptionService encryptionService,
  IMiscelaneousService miscelaneousService) : ControllerBase
{
  private readonly IDataEncryptionService _encryptionService = encryptionService;
  private readonly IMiscelaneousService _miscelaneousService = miscelaneousService;
  private readonly IUserService _service = userService;


  [HttpPost("v1/create")]
  [SwaggerOperation(Summary = "Create a new user.")]
  public async Task<IActionResult> CreateOneUserAsync(
    [FromBody] CreateUserDto body
  )
  {
    body.CPF = _encryptionService.Hash(body.CPF);

    var createdUserResult = await _service.CreateOneUserAsync(
      body
    );

    var getCreateUserEmailTemplateContent =
      await _miscelaneousService.GetOneEmailTemplateAsync("create-email-template");
    SmtpEmailService.SendEmail(createdUserResult.UserEmail, "Welcome to Foodie!",
      getCreateUserEmailTemplateContent.EmailTemplateContent.Replace("{{username}}",
        createdUserResult.UserName));

    return StatusCode(
      StatusCodes.Status200OK, new
      {
        result = new
        {
          email = createdUserResult.UserEmail
        }
      }
    );
  }


  [HttpPost("v1/login")]
  [SwaggerOperation(Summary = "Return a token and refresh token based on user's email or phone.")]
  public async Task<IActionResult> AuthenticateAsync(
    [FromBody] AuthenticateUserDTO body
  )
  {
    var user = await _service.GetOneUserAsync(body);

    var token = TokenService.GenerateToken(user);
    var refreshToken = TokenService.GenerateRefreshToken();
    TokenService.SaveRefreshToken(user.Phone, refreshToken);

    return StatusCode(
      StatusCodes.Status200OK, new
      {
        result = new
        {
          token, refreshToken
        }
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
    if ( string.IsNullOrEmpty(authorization) && string.IsNullOrEmpty(refreshToken) )
      return StatusCode(
        StatusCodes.Status400BadRequest,
        new { detail = "JWT Token or Refresh Token is missing" }
      );
    ;

    var principal = TokenService.GetPrincipalFromExpiredToken(authorization);
    var userPhone = principal.Identity.Name;
    var savedRefreshToken = TokenService.GetRefreshToken(userPhone);
    if ( savedRefreshToken != refreshToken )
      throw new SecurityTokenException("Invalid Refresh Token!");

    var newJwtToken = TokenService.GenerateToken(principal.Claims);
    var newRefreshToken = TokenService.GenerateRefreshToken();
    TokenService.DeleteRefreshToken(userPhone, refreshToken);
    TokenService.SaveRefreshToken(userPhone, newRefreshToken);

    return StatusCode(
      StatusCodes.Status200OK, new
      {
        result = new
        {
          token = newJwtToken,
          refreshToken = newRefreshToken
        }
      }
    );
  }


  [HttpGet("v1/info")]
  [Authorize]
  [SwaggerOperation(Summary = "Gets user infos.")]
  public async Task<IActionResult> GetUserInfoAsync(
    [FromHeader] string authorization
  )
  {
    if ( string.IsNullOrEmpty(authorization) )
      return StatusCode(
        StatusCodes.Status400BadRequest,
        new { detail = "JWT Token or Refresh Token is missing" }
      );
    ;

    var userPhone = TokenService.DecodeToken(authorization);

    var user = await _service.GetOneUserAsync(userPhone);

    return StatusCode(
      StatusCodes.Status200OK,
      new
      {
        result = new
        {
          userAvatar = user.Avatar,
          userName = user.Name
        }
      }
    );
  }


  [HttpGet("v1/info/get/addresses")]
  [Authorize]
  [SwaggerOperation(Summary = "Gets user registered addresses.")]
  public async Task<IActionResult> GetUserAddressesAsync(
    [FromHeader] string authorization
  )
  {
    if ( string.IsNullOrEmpty(authorization) )
      return StatusCode(
        StatusCodes.Status400BadRequest,
        new { detail = "JWT Token or Refresh Token is missing" }
      );
    ;

    var userPhone = TokenService.DecodeToken(authorization);

    var user = await _service.GetOneUserAsync(userPhone);

    var userAddresses = await _service.GetUserAddressesAsync(user.Id);

    return StatusCode(
      StatusCodes.Status200OK,
      new
      {
        result = new
        {
          userAddresses
        }
      }
    );
  }


  [HttpPost("v1/info/create/address")]
  [Authorize]
  [SwaggerOperation(Summary = "Created new user address.")]
  public async Task<IActionResult> CreateOneUserAddressAsync(
    [FromHeader] string authorization,
    [FromBody] CreateUserAddressDto body
  )
  {
    if ( string.IsNullOrEmpty(authorization) )
      return StatusCode(
        StatusCodes.Status400BadRequest,
        new { detail = "JWT Token or Refresh Token is missing" }
      );
    ;

    var userPhone = TokenService.DecodeToken(authorization);

    var user = await _service.GetOneUserAsync(userPhone);
    var userAddress = _service.CreateUserAddressAsync(body, user.Id);

    return StatusCode(
      StatusCodes.Status200OK,
      new
      {
        result = "User address saved successfully!"
      }
    );
  }


  [HttpGet("v1/list")]
  public async Task<IActionResult> GetUsersListAsync()
  {
    var usersList = await _service.GetUsersListAsync();

    return StatusCode(
      StatusCodes.Status200OK, new
      {
        result = new
        {
          usersList
        }
      }
    );
  }
}