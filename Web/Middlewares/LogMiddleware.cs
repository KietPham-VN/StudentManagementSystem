namespace Web.Middlewares
{
    public class LogMiddleware(ILogger<LogMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occured while processing the request.");
                context.Response.StatusCode = 501;
                await context.Response.WriteAsync("An error occurred while processing the request.");
            }
            finally
            {
                var request = context.Request;
                var response = context.Response;
                logger.LogInformation("Request: {0} {1}", request.Method, request.Path);

                logger.LogInformation($"Request: {request.Method} {request.Path}");
                logger.LogInformation($"Respone: " + response.StatusCode);
            }
        }
    }
}