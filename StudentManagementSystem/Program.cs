using Serilog;
using StudentManagementSystem.Application.Middlewares;
using StudentManagementSystem.Application.Services.Implementation;
using StudentManagementSystem.Application.Services.Interface;
using StudentManagementSystem.Infrastructures;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseStudentService, CourseStudentService>();
builder.Services.AddSingleton<LogMiddleware>();
builder.Services.AddSingleton<RateLimitMiddleware>();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Warning()
    .WriteTo.File("D:\\LearningMaterial\\MyOwnCarrerPath\\C#\\StudentManagementSystem\\Log\\log.txt",
        rollingInterval: RollingInterval.Minute)
    .CreateLogger();
builder.Host.UseSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseExceptionHandler("/Error");

app.UseHttpsRedirection();

app.UseAuthorization();

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
app.UseMiddleware<LogMiddleware>();
app.UseMiddleware<RateLimitMiddleware>();
await app.RunAsync();