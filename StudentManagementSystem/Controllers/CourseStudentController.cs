using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Application.DTOs.CourseStudentDTO;
using StudentManagementSystem.Application.Services.Interface;

namespace StudentManagementSystem.Controllers
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
        public IEnumerable<CourseScoreViewModel> GetScoresByStudent(int studentId)
        {
            return courseService.GetScoresByStudent(studentId);
        }

        [HttpGet("average/{studentId}")]
        public float GetAverageScore(int studentId)
        {
            return courseService.GetAverageScore(studentId);
        }

        [HttpPost("register")]
        public bool RegisterCourse(RegisterCourseModel registerCourse)
        {
            return courseService.RegisterCourse(registerCourse);
        }
    }
}