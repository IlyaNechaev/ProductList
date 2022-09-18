using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Web.Controllers
{
    [Route("/api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        EShopDbContext _dbContext;

        public UserController(EShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<User> GetUser(string id)
        {
            var userId = Guid.Parse(id);
            var user = await _dbContext.Users.FindAsync(userId);

            return user;
        }

        [HttpPut("add")]
        public async Task<User> AddUser([FromBody] User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        [HttpDelete("rm")]
        public async void RemoveUser(string id)
        {
            var user = await GetUser(id);
            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();
        }
    }
}
