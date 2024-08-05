using FoodieAPI.Domain;
using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Interfaces.Services;
using FoodieAPI.Services;
using Microsoft.AspNetCore.Mvc;

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