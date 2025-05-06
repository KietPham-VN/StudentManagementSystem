using Application.DTOs.SchoolDTO;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController(ISchoolService schoolService) : ControllerBase
    {
        [HttpGet]
        public IEnumerable<SchoolViewModel> GetSchools(int? SchoolId)
        {
            return schoolService.GetSchools(SchoolId);
        }

        [HttpPost]
        public IActionResult CreateSchool(SchoolCreateModel school)
        {
            return Ok(schoolService.CreateSchool(school));
        }

        [HttpPut]
        public IActionResult UpdateSchool(SchoolUpdateModel updateSchool)
        {
            return Ok(schoolService.UpdateSchool(updateSchool));
        }

        [HttpDelete]
        public IActionResult DeleteSchool(int id)
        {
            return Ok(schoolService.DeleteSchool(id));
        }
    }
}