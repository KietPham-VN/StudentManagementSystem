using Application.DTOs.UserDTO;
using TodoWeb.Application.Services.User;

namespace TodoWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register(RegisterUserModel users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_userService.Register(users));
        }

        [HttpPost("/login")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)] // Add response type annotation
        public IActionResult Login(UserLoginModel users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_userService.Login(users));
        }
    }
}