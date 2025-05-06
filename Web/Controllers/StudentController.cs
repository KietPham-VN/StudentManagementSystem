using Application.DTOs.StudentDTO;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController(IStudentService studentService, ILogger<StudentController> logger) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> GetStudents([FromQuery] int id)
        {
            var result = await studentService.GetStudent(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> GetAllStudents()
        {
            var result = await studentService.GetAllStudents();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<StudentCreateModel>> CreateStudent([FromBody] StudentCreateModel student)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await studentService.CreateStudent(student);
            return CreatedAtAction(nameof(GetStudents), new { id = result.Id }, result);
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