using StudentManagementSystem.Application.DTOs.SchoolDTO;

namespace StudentManagementSystem.Application.Services.Interface
{
    public interface ISchoolService
    {
        IEnumerable<SchoolViewModel> GetSchools(int? SchoolId);

        bool CreateSchool(CreateSchoolModel School);

        bool UpdateSchool(UpdateSchoolModel updateSchool);

        bool DeleteSchool(int id);
    }
}