using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Application.DTOs.StudentDTO;
using StudentManagementSystem.Application.Services.Interface;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController(IStudentService studentService, ILogger<StudentController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> GetStudents([FromQuery] int? id)
        {
            try
            {
                var result = await studentService.GetStudents(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching students");
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentCreateModel>> CreateStudent([FromBody] StudentCreateModel student)
        {
            try
            {
                var result = await studentService.CreateStudent(student);
                return CreatedAtAction(nameof(GetStudents), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error creating student");
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentUpdateModel>> UpdateStudent(int id, [FromBody] StudentUpdateModel student)
        {
            if (id != student.Id)
                return BadRequest("ID không khớp.");

            try
            {
                var result = await studentService.UpdateStudent(student);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating student");
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentViewModel>> DeleteStudent(int id)
        {
            try
            {
                var result = await studentService.DeleteStudent(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error deleting student");
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }
    }
}