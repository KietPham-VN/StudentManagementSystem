using Application.Services.Implementation;
using Web.ActionFilters;
using Web.Middlewares;

namespace Web;

public static class DependencyInjection
{
    public static void AddService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IStudentService, StudentService>();
        serviceCollection.AddScoped<ISchoolService, SchoolService>();
        serviceCollection.AddScoped<ICourseService, CourseService>();
        serviceCollection.AddScoped<ICourseStudentService, CourseStudentService>();
        serviceCollection.AddSingleton<LogMiddleware>();
        serviceCollection.AddSingleton<RateLimitMiddleware>();
        serviceCollection.AddSingleton<ICacheService, CacheService>();
        serviceCollection.AddSingleton<LogFilter>();
        serviceCollection.AddScoped<IUserService, UserService>();
    }
}