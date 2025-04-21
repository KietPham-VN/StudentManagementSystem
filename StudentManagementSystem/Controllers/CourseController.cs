using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Application.DTOs.CourseDTO;
using StudentManagementSystem.Application.Services.Interface;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CourseViewModel> GetCourses(int? CourseId)
        {
            return courseService.GetCourses(CourseId);
        }

        [HttpPost]
        public async Task<bool> CreateCourse(CreateCourseModel course)
        {
            return await courseService.CreateCourse(course);
        }

        [HttpPut]
        public bool UpdateCourse(UpdateCourseModel course)
        {
            return courseService.UpdateCourse(course);
        }

        [HttpDelete]
        public bool DeleteCourse(int courseId)
        {
            return courseService.DeleteCourse(courseId);
        }
    }
}