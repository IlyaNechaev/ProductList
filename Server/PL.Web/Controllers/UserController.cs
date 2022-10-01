using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Web.Controllers
{
    [Route("/api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<User> GetUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            return user;
        }

        [HttpPut("add")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var result = await _userService.AddUserAsync(user);

            if (!result)
            {
                return Ok("Не удалось добавить пользователя");
            }

            return Ok(user);
        }

        [HttpDelete("rm")]
        public async Task<IActionResult> RemoveUser(string id)
        {
            var userId = Guid.Parse(id);
            var result = await _userService.RemoveUserByIdAsync(userId);

            if (!result)
            {
                return Ok("Не удалось удалить пользователя");
            }

            return Ok($"Пользователь {id} удален");
        }
    }
}
