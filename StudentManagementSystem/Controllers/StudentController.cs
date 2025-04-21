using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Application.DTOs.StudentDTO;
using StudentManagementSystem.Application.Services.Interface;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(IStudentService studentService, ILogger<StudentController> logger) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents(int? Id)
        {
            try
            {
                if (Id == 10)
                {
                    logger.LogWarning("Id is 10, returning empty result");
                }
                logger.LogInformation("GetStudents method called with Id: {Id}", Id);
                return Ok(studentService.GetStudents(Id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi server: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentCreateModel student)
        {
            try
            {
                return Ok(studentService.CreateStudent(student));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi server: " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateStudent(StudentUpdateModel student)
        {
            try
            {
                return Ok(studentService.UpdateStudent(student));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi server: " + ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                return Ok(studentService.DeleteStudent(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi server: " + ex.Message);
            }
        }
    }
}