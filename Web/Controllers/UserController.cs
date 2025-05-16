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
            var user = userService.Login(users);
            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }

            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Role", user.Role.ToString());
            return Ok("Login successfully");
        }

        [HttpPost("logout")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Logout()
        {
            HttpContext.Sesion.Clear();
            // Implement logout logic here
            return Ok("Logged out successfully");
        }
    }
}