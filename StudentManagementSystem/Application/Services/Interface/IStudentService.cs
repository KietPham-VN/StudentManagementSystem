using StudentManagementSystem.Application.DTOs.StudentDTO;

namespace StudentManagementSystem.Application.Services.Interface
{
    public interface IStudentService
    {
        IEnumerable<StudentViewModel> GetStudents(int? Id);

        StudentCreateModel CreateStudent(StudentCreateModel student);

        StudentUpdateModel UpdateStudent(StudentUpdateModel student);

        StudentViewModel DeleteStudent(int id);
    }
}