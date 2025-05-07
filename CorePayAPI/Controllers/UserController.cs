using CorePayAPI.Data;
using CorePayAPI.Entities;
using CorePayAPI.Repository.Interface;
using CorePayAPI.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CorePayAPI.Controllers
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

        // GET api/<UserController>/5
        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var response = _userService.ConsultUser(userId);

            if (!response.isSucess)
                return BadRequest(response);

            return Ok(response);

        }
    }
}
