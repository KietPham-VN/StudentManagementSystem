using StudentManagementSystem.Application.DTOs.StudentDTO;

namespace StudentManagementSystem.Application.Services.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> GetStudents(int? id);

        Task<StudentCreateModel> CreateStudent(StudentCreateModel student);

        Task<StudentUpdateModel> UpdateStudent(StudentUpdateModel student);

        Task<StudentViewModel> DeleteStudent(int id);
    }
}