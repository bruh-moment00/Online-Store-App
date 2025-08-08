using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend.Core.AuthModels;
using Online_Store_Backend.Domain.Authentication.Interfaces;

namespace Online_Store_Backend.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService userAuthService;
        private readonly IConfiguration configuration;
        public AuthController(IAuthService userAuthService, IConfiguration configuration)
        {
            this.userAuthService = userAuthService;
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("user")]
        public async Task<IActionResult> UserLogin([FromBody] AuthData data)
        {
            if (data == null || string.IsNullOrWhiteSpace(data.Password))
            {
                return BadRequest("Введите пароль");
            }

            var loginResponse = await userAuthService.ValidateAndGetUserTokenAsync(data);

            if (loginResponse == null)
            {
                return BadRequest("Неверный логин и/или пароль");
            }

            return Ok(loginResponse);
        }

        [AllowAnonymous]
        [HttpPost("employee")]
        public async Task<IActionResult> EmployeeLogin([FromBody] AuthData data)
        {
            if (data == null || string.IsNullOrWhiteSpace(data.Password))
            {
                return BadRequest("Введите пароль");
            }

            var loginResponse = await userAuthService.ValidateAndGetEmployeeTokenAsync(data);

            if (loginResponse == null)
            {
                return BadRequest("Неверный логин и/или пароль");
            }

            return Ok(loginResponse);
        }

        [AllowAnonymous]
        [HttpPost("validateUser")]
        public async Task<IActionResult> ValidateUserToken([FromBody] string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return BadRequest("Токен не может быть пустым");
            }
            var isValid = await userAuthService.ValidateUserTokenAsync(token);
            return Ok(isValid);
        }

        [AllowAnonymous]
        [HttpPost("validateEmployee")]
        public async Task<IActionResult> ValidateEmployeeToken([FromBody] string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return BadRequest("Токен не может быть пустым");
            }
            var isValid = await userAuthService.ValidateEmployeeTokenAsync(token);
            return Ok(isValid);
        }

        [Authorize(Roles = "employee")]
        [HttpPost("getEmployeeId")]
        public IActionResult GetEmployeeId()
        {
            var userIdClaim = HttpContext.User.FindFirst("id");

            if (userIdClaim == null)
                return BadRequest("User ID not found");
            else
                return Ok(Convert.ToInt64(userIdClaim.Value));
        }

        [Authorize(Roles = "user")]
        [HttpPost("getUserId")]
        public IActionResult GetUserId()
        {
            var userIdClaim = HttpContext.User.FindFirst("id");

            if (userIdClaim == null)
                return BadRequest("User ID not found");
            else 
                return Ok(Convert.ToInt64(userIdClaim.Value));
        }
    }
}
