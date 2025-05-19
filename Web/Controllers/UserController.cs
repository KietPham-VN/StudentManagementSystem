using System.Security.Claims;
using Application.DTOs.UserDTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Web.Controllers;

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
            return BadRequest("Invalid email or password");
        }

        HttpContext.Session.SetString("UserId", user.Id.ToString());
        HttpContext.Session.SetString("Role", user.Role.ToString());
        return Ok("Login successfully");
    }

    [HttpPost]
    [Route("login-cookies")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> LoginCookiesAsync(UserLoginModel userLoginModel)
    {
        var user = userService.Login(userLoginModel);
        if (user == null)
        {
            return Unauthorized("Invalid email or password");
        }
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.EmailAddress),
            new(ClaimTypes.Role, user.Role.ToString())
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

        return Ok("Login successfully");
    }

    [HttpPost]
    [Route("login-jwt")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> LoginJwtAsync(UserLoginModel userLoginModel)
    {
        var user = userService.Login(userLoginModel);
        if (user == null)
        {
            return Unauthorized("Invalid email or password");
        }
        var token = userService.GenerateJwt(user);

        return Ok(token);
    }

    [HttpPost("logout")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return Ok("Logged out successfully");
    }
}