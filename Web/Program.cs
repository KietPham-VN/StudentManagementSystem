// scan assembly Application.dll nơi chứa StudentCreateModelValidator
using Application.ModelValidators;  // nhớ thêm reference đến project Application
using Application.Services.Implementation;
using Domain.Abstractions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructures.Database;
using Serilog;
using Web.ActionFilters;
using Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(option =>
{
    option.Filters.Add<TestFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseStudentService, CourseStudentService>();
builder.Services.AddSingleton<LogMiddleware>();
builder.Services.AddSingleton<RateLimitMiddleware>();
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddSingleton<LogFilter>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddMemoryCache();

builder.Services.AddValidatorsFromAssemblyContaining<StudentCreateModelValidator>();

var slnRoot = Directory.GetParent(AppContext.BaseDirectory)?
                        .Parent?.Parent?.Parent?.Parent?.FullName;

var logDir = Path.Combine(slnRoot!, "Logs");

if (!Directory.Exists(logDir))
{
    Directory.CreateDirectory(logDir);
}

var logFilePath = Path.Combine(logDir, "log.txt");

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
    .WriteTo.Console()
    .CreateLogger();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<LogMiddleware>();
app.UseMiddleware<RateLimitMiddleware>();
app.MapControllers();

app.Use(async (context, next) =>
{
    Console.WriteLine("Request to middleware 1");
    await next(context);
    Console.WriteLine("Response to middleware 1");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("Request to middleware 2");
    await next(context);
    Console.WriteLine("Response to middleware 2");
});
await app.RunAsync();