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

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.File("C:\\Users\\anhki\\OneDrive\\Desktop\\try.txt", rollingInterval: RollingInterval.Minute)
//    .MinimumLevel.Warning()
//    .CreateLogger();

//builder.Host.UseSerilog();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();