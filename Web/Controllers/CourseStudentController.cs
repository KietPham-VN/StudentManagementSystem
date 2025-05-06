using Application.DTOs.CourseStudentDTO;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseStudentController(ICourseStudentService courseService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCourseStudents(int? courseId, int? studentId)
        {
            try
            {
                var courseStudent = courseService.GetCourseStudents(courseId, studentId);
                return Ok(courseStudent);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCourseStudent(CourseStudentCreateModel courseStudent)
        {
            try
            {
                var createdCourseStudent = courseService.CreateCourseStudent(courseStudent);
                return CreatedAtAction(nameof(GetCourseStudents), new { courseId = createdCourseStudent.CourseId, studentId = createdCourseStudent.StudentId }, createdCourseStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{courseId}/{studentId}")]
        [ProducesResponseType(typeof(CourseStudentUpdateModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCourseStudent(int courseId, int studentId, CourseStudentUpdateModel updateCourseStudent)
        {
            try
            {
                var updatedCourseStudent = courseService.UpdateCourseStudent(courseId, studentId, updateCourseStudent);
                return Ok(updatedCourseStudent);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("scores/{studentId}")]
        public IEnumerable<CourseStudentViewModel> GetScoresByStudent(int studentId)
        {
            try
            {
                var courseStudent = courseService.GetScoresByStudent(studentId);
                return courseStudent;
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message);
            }
        }

        [HttpGet("average/{studentId}")]
        public float GetAverageScore(int studentId)
        {
            try
            {
                return courseService.GetAverageScore(studentId);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message);
            }
        }
    }
}