using Application.DTOs.SchoolDTO;

namespace Application.Services.Interface
{
    public interface ISchoolService
    {
        IEnumerable<SchoolViewModel> GetSchools(int? SchoolId);

        SchoolCreateModel CreateSchool(SchoolCreateModel School);

        SchoolUpdateModel UpdateSchool(SchoolUpdateModel updateSchool);

        SchoolViewModel DeleteSchool(int id);
    }
}