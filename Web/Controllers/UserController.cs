using Application.DTOs.UserDTO;

namespace Web.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public IActionResult Register(UserRegisterModel users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(userService.Register(users));
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult Login(UserLoginModel users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(userService.Login(users));
        }

        [HttpPost("logout")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Logout()
        {
            // Implement logout logic here
            return Ok("Logged out successfully");
        }
    }
}