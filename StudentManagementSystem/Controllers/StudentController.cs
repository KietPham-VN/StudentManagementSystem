using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Application.DTOs.StudentDTO;
using StudentManagementSystem.Application.Services.Interface;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(IStudentService StudentService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents(int? Id)
        {
            try
            {
                return Ok(StudentService.GetStudents(Id));
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
                return Ok(StudentService.CreateStudent(student));
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
                return Ok(StudentService.UpdateStudent(student));
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
                return Ok(StudentService.DeleteStudent(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi server: " + ex.Message);
            }
        }
    }
}