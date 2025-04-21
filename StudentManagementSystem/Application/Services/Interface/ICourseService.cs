using StudentManagementSystem.Application.DTOs.CourseDTO;

namespace StudentManagementSystem.Application.Services.Interface
{
    public interface ICourseService
    {
        IEnumerable<CourseViewModel> GetCourses(int? CourseId);

        Task<bool> CreateCourse(CreateCourseModel course);

        bool UpdateCourse(UpdateCourseModel course);

        bool DeleteCourse(int courseId);
    }
}