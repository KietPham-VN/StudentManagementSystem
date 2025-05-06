using Application.DTOs.CourseStudentDTO;

namespace Application.Services.Interface
{
    public interface ICourseStudentService
    {
        CourseStudentViewModel GetCourseStudents(int? courseId, int? studentId);

        CourseStudentCreateModel CreateCourseStudent(CourseStudentCreateModel courseStudent);

        CourseStudentUpdateModel UpdateCourseStudent(int courseId, int studentId, CourseStudentUpdateModel updateCourseStudent);

        IEnumerable<CourseStudentViewModel> GetScoresByStudent(int studentId);

        float GetAverageScore(int studentId);
    }
}