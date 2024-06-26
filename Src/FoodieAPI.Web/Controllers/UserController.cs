using FoodieAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodieAPI.Web.Controllers
{
  [Route("v1/account")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _service;
    public UserController(IUserService userService)
    {
      _service = userService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetUsersListAsync()
    {
      var usersList = await _service.GetUsersListAsync();

      return StatusCode(
        StatusCodes.Status200OK, new { usersList }
      );
    }
  }
}