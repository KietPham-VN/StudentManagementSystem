using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Application.ActionFilters;
using StudentManagementSystem.Application.DTOs.CourseDTO;
using StudentManagementSystem.Application.Services.Interface;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(LogFilter))]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCourses(int? CourseId)
        {
            try
            {
                return Ok(courseService.GetCourses(CourseId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi server: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCourse(CreateCourseModel course)
        {
            try
            {
                return Ok(courseService.CreateCourse(course));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi server: " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateCourse(CourseUpdateModel course)
        {
            try
            {
                return Ok(courseService.UpdateCourse(course));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi server: " + ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCourse(int courseId)
        {
            try
            {
                return Ok(courseService.DeleteCourse(courseId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi server: " + ex.Message);
            }
        }
    }
}