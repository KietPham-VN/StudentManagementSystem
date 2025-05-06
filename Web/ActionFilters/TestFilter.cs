using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.ActionFilters
{
    public class TestFilter : IActionFilter, IResultFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {   //chạy trước khi endpoint execute
            Console.WriteLine("OnActionExecuting");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {   //sau khi action execute và trả về kết quả
            Console.WriteLine("OnActionExecuted");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("OnResultExecuting");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("OnResultExecuted");
        }

    }
}