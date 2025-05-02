using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController(ILogger<ErrorController> logger) : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionHandler?.Error.Message;
            logger.LogError(exception, "An error occurred while processing the request.");
            return new JsonResult(new
            {
                StatusCode = 500,
                Message = exception
            });
        }
    }
}