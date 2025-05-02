using CorePayAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CorePayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET api/<UserController>/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> ConsultUser(int userId)
        {
            var user = await _dataContext.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(new{user.UserId, user.Name, user.Balance});
        }
    }
}
