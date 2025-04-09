using System.Net;
using System.Text.Json;
using StudentManagementSystem.Domain.Exceptions;

namespace StudentManagementSystem.WebAPI.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(context, ex.Message, ex.PropertyName, HttpStatusCode.BadRequest);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, ex.Message, null, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, "An unexpected error occurred.", null, HttpStatusCode.InternalServerError, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, string message, string? property, HttpStatusCode statusCode, Exception? ex = null)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(new
            {
                error = message,
                property,
                detail = statusCode == HttpStatusCode.InternalServerError ? ex?.Message : null
            });

            return context.Response.WriteAsync(result);
        }
    }
}