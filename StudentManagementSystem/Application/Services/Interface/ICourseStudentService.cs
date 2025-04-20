using StudentManagementSystem.Application.DTOs.CourseStudentDTO;

namespace StudentManagementSystem.Application.Services.Interface
{
    public interface ICourseStudentService
    {
        IEnumerable<CourseStudentViewModel> GetCourseStudents(int? courseId, int? studentId);

        bool AddCourseStudent(CreateCourseStudentModel courseStudent);

        bool UpdateCourseStudent(int courseId, int studentId, UpdateCourseStudentModel updateCourseStudent);

        IEnumerable<CourseScoreViewModel> GetScoresByStudent(int studentId);

        float GetAverageScore(int studentId);

        bool RegisterCourse(RegisterCourseModel registerCourse);
    }
}