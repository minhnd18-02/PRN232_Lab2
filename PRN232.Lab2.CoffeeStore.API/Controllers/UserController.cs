using Microsoft.AspNetCore.Mvc;
using PRN232.Lab2.CoffeeStrore.Services.Interfaces;
using PRN232.Lab2.CoffeeStrore.Services.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRN232.Lab2.CoffeeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUser loginObject)
        {
            var result = await _userService.LoginAsync(loginObject);

            if (!result.Success)
            {
                return StatusCode(401, result);
            }
            else
            {
                return Ok(
                    new
                    {
                        success = result.Success,
                        message = result.Message,
                        token = result.DataToken,
                        userName = result.FullName,
                        hint = result.HintId,
                    }
                );
            }
        }

    }
}
