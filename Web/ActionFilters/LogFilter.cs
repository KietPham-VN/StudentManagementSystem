using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.ActionFilters
{
    public class LogFilter(ILogger<LogFilter> logger) : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            const string messageTemplate = "Exception occurred: {ExceptionMessage}";
            logger.LogError(messageTemplate, exception.Message); // hoặc LogWarning, LogInformation, tuỳ Serilog config

            context.Result = new ObjectResult(new
            {
                Message = "An error occurred while processing your request. Please contact the admin for more information.",
                Detail = exception.Message
            })
            {
                StatusCode = 500
            };
        }
    }
}
