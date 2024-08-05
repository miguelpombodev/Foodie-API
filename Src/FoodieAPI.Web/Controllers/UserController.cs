using FoodieAPI.Domain.DTO.Requests;
using FoodieAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodieAPI.Web.Controllers
{
  [Route("account")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _service;
    public UserController(IUserService userService)
    {
      _service = userService;
    }

    [HttpPost("v1/create")]
    public async Task<IActionResult> CreateOneUserAsync(
      [FromBody] CreateUserDTO body
    )
    {
      var usersList = await _service.CreateOneUserAsync(
        body
      );

      return StatusCode(
        StatusCodes.Status200OK, new { usersList }
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