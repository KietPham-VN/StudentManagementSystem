using Application.DTOs.SchoolDTO;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin,Student")]
    public class SchoolController(ISchoolService schoolService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SchoolViewModel>), StatusCodes.Status200OK)]
        public IEnumerable<SchoolViewModel> GetSchools(int? SchoolId)
        {
            return schoolService.GetSchools(SchoolId);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SchoolCreateModel), StatusCodes.Status200OK)]
        public IActionResult CreateSchool(SchoolCreateModel school)
        {
            return Ok(schoolService.CreateSchool(school));
        }

        [HttpPut]
        [ProducesResponseType(typeof(SchoolUpdateModel), StatusCodes.Status200OK)]
        public IActionResult UpdateSchool(SchoolUpdateModel updateSchool)
        {
            return Ok(schoolService.UpdateSchool(updateSchool));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(SchoolViewModel), StatusCodes.Status200OK)]
        public IActionResult DeleteSchool(int id)
        {
            return Ok(schoolService.DeleteSchool(id));
        }
    }
}