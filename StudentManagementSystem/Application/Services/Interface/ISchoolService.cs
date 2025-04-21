

using StudentManagementSystem.Application.DTOs.SchoolDTO;

namespace StudentManagementSystem.Application.Services.Interface
{
    public interface ISchoolService
    {
        IEnumerable<SchoolViewModel> GetSchools(int? SchoolId);

        SchoolCreateModel CreateSchool(SchoolCreateModel School);

        SchoolUpdateModel UpdateSchool(SchoolUpdateModel updateSchool);

        SchoolViewModel DeleteSchool(int id);
    }
}