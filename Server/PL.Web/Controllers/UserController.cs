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

        [HttpGet("/api/users")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _userService.GetUsersByLoginAsync(string.Empty);

            return users;
        }

        [HttpGet]
        public async Task<User> GetUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            return user;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] UserView userView)
        {
            var user = userView.ToUser();
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

        [HttpGet("/test")]
        public IActionResult Test()
        {
            return Ok("Test passed");
        }
    }
}
