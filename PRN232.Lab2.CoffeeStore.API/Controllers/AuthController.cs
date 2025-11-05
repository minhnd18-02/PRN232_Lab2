using Microsoft.AspNetCore.Mvc;
using PRN232.Lab2.CoffeeStore.Services.IServices;
using PRN232.Lab2.CoffeeStore.Services.ViewModels.Auths;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRN232.Lab2.CoffeeStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;   
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            var result = await _userService.Login(loginRequest);

            if (!result.Success)
            {
                return StatusCode(401, result);
            }
            else
            {
                return Ok(result);
            }
        }

    }
}
