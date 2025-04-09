using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Application.DTOs;
using StudentManagementSystem.Application.UseCases.Students;

namespace StudentManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController(
        CreateStudentHandler createStudentHandler,
        GetStudentHandler getStudentHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? id, CancellationToken cancellationToken)
        {
            var students = await getStudentHandler.Handle(id, cancellationToken);

            if (id.HasValue && students.Count == 0)
                return NotFound(new { error = "Student not found" });

            if (id.HasValue)
                return Ok(students[0]);

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentId = await createStudentHandler.Handle(dto, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = studentId }, new { id = studentId });
        }
    }
}