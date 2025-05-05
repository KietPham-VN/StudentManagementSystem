using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentManagementSystem.Application.ActionFilters
{
    public class LogFilter : IExceptionFilter
    {
        private readonly ILogger<LogFilter> _logger;

        public LogFilter(ILogger<LogFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var message = $@"Exception: {exception.Message}";

            _logger.LogError(message);
            context.Result = new ObjectResult(new
            {
                Message = @"An error occured while processing your request.
                            Please contact with admin for more information",
                Detail = exception.Message
            })
            {
                StatusCode = 500
            };
        }
    }
}