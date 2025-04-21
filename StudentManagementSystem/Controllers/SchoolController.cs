using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Application.DTOs.SchoolDTO;
using StudentManagementSystem.Application.Services.Interface;

namespace StudentManagementSystem.Controllers
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
        public bool CreateSchool(CreateSchoolModel school)
        {
            return schoolService.CreateSchool(school);
        }

        [HttpPut]
        public bool UpdateSchool(SchoolUpdateModel updateSchool)
        {
            return schoolService.UpdateSchool(updateSchool);
        }

        [HttpDelete]
        public bool DeleteSchool(int id)
        {
            return schoolService.DeleteSchool(id);
        }
    }
}