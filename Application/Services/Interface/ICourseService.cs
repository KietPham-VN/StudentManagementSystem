using Application.DTOs.CourseDTO;

namespace Application.Services.Interface
{
    public interface ICourseService
    {
        IEnumerable<CourseViewModel> GetCourses(int? courseId);

        CreateCourseModel CreateCourse(CreateCourseModel course);

        CourseUpdateModel UpdateCourse(CourseUpdateModel course);

        CourseViewModel DeleteCourse(int courseId);
    }
}