using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.ActionFilters;

public class AuthorizationFilter(string allowedRoles) : IAuthorizationFilter
{
    private readonly string[] _allowedRoles = allowedRoles.Split(",");

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userId = context.HttpContext.Session.GetInt32("UserId");

        if (userId == null)
        {
            context.Result = new StatusCodeResult(401);
            return;
        }
        var role = context.HttpContext.Session.GetString("Role");

        if (string.IsNullOrEmpty(role) || !_allowedRoles.Contains(role))
        {
            context.Result = new StatusCodeResult(403);
        }
    }
}