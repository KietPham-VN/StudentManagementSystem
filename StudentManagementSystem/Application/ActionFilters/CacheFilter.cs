using Microsoft.AspNetCore.Mvc.Filters;
using StudentManagementSystem.Application.Services.Interface;

namespace StudentManagementSystem.Application.ActionFilters
{
    public class CacheFilter(ICacheService cacheService, int duration) : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var key = context.HttpContext.Request.Path.ToString();
            var data = cacheService.Get("Key");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }

}
