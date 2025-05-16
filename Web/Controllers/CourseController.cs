using Application.DTOs.CourseDTO;
using Web.ActionFilters;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(LogFilter), Arguments = [LogLevel.Warning])]
    [AuditFilter]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseViewModel>), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetCourses(int? courseId)
        {
            try
            {
                return Ok(courseService.GetCourses(courseId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi server: " + ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateCourseModel), 200)]
        [ProducesResponseType(500)]
        [TypeFilter(typeof(CacheFilter), Arguments = [60])]
        public IActionResult CreateCourse(CreateCourseModel course)
        {
            try
            {
                return Ok(courseService.CreateCourse(course));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(CourseUpdateModel), 200)]
        [ProducesResponseType(500)]
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
        [ProducesResponseType(typeof(CourseViewModel), 200)]
        [ProducesResponseType(500)]
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