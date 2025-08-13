using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Store_Backend.AuthHelpers;
using Online_Store_Backend.Domain.Authentication.Dto;
using Online_Store_Backend.Domain.Employees.Services;
using Online_Store_Backend.Domain.Users.Dto;
using Online_Store_Backend.Domain.Users.Services.Interfaces;

namespace Online_Store_Backend.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        [Authorize(Roles = "employee")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(long id)
        {
            if (!(HttpContext.User.IsInRole("employee") || AuthHelper.CheckSameUserId(HttpContext, id)))
            {
                return Forbid("Access denied");
            }
            var user = await userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserPostDto user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }
            var createdUserID = await userService.InsertUser(user);
            return Ok(createdUserID);
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto user)
        {
            if (user == null || id != user.ID)
            {
                return BadRequest("Invalid user data.");
            }
            var updatedUser = await userService.UpdateUser(user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }
        [HttpPut("{id}/password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(long id, [FromBody] PasswordDto passwordDto)
        {
            if (HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value != id.ToString())
            {
                return Forbid("Access denied");
            }
            if (passwordDto == null || id != passwordDto.ID)
            {
                return BadRequest("Invalid password data.");
            }
            var changed = await userService.ChangePassword(passwordDto);
            if (!changed)
            {
                return NotFound();
            }
            return Ok(true);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await userService.DeleteUser(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
