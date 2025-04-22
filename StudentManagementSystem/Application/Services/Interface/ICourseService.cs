using StudentManagementSystem.Application.DTOs.CourseDTO;

namespace StudentManagementSystem.Application.Services.Interface
{
    public interface ICourseService
    {
        IEnumerable<CourseViewModel> GetCourses(int? CourseId);

        CreateCourseModel CreateCourse(CreateCourseModel course);

        CourseUpdateModel UpdateCourse(CourseUpdateModel course);

        CourseViewModel DeleteCourse(int courseId);
    }
}