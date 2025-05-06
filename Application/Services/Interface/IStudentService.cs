namespace Application.Services.Interface
{
    public interface IStudentService
    {
        Task<IReadOnlyList<StudentViewModel>> GetStudents();

        Task<IEnumerable<StudentViewModel>> GetAllStudents();

        Task<IReadOnlyList<StudentViewModel>> GetStudent(int id);

        Task<StudentCreateModel> CreateStudent(StudentCreateModel student);

        Task<StudentUpdateModel> UpdateStudent(StudentUpdateModel student);

        Task<StudentViewModel> DeleteStudent(int id);
    }
}