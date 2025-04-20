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
        public IEnumerable<CourseStudentViewModel> GetCourseStudents(int? courseId, int? studentId)
        {
            return courseService.GetCourseStudents(courseId, studentId);
        }

        [HttpPost]
        public bool AddCourseStudent(CreateCourseStudentModel courseStudent)
        {
            return courseService.AddCourseStudent(courseStudent);
        }

        [HttpPut("{courseId}/{studentId}")]
        public bool UpdateCourseStudent(int courseId, int studentId, UpdateCourseStudentModel updateCourseStudent)
        {
            return courseService.UpdateCourseStudent(courseId, studentId, updateCourseStudent);
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