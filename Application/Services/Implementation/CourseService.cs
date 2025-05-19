using Application.DTOs.CourseDTO;
using Application.Services.Interface;
using Domain.Entities;

namespace Application.Services.Implementation
{
    public class CourseService(IApplicationDbContext context) : ICourseService
    {
        public IEnumerable<CourseViewModel> GetCourses(int? courseId)
        {
            var course = context.Courses.AsQueryable();
            if (courseId.HasValue)
            {
                course = course.Where(school => school.CourseId == courseId);
            }

            return [.. course.Select(course => new CourseViewModel
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                StartDate = course.StartDate,
            })];
        }

        public CreateCourseModel CreateCourse(CreateCourseModel course)
        {
            var newCourse = new Course
            {
                CourseName = course.CourseName,
                StartDate = course.StartDate,
            };
            context.Courses.Add(newCourse);
            context.SaveChanges();
            return new CreateCourseModel
            {
                CourseId = newCourse.CourseId,
                CourseName = newCourse.CourseName,
                StartDate = newCourse.StartDate,
            };
        }

        public CourseUpdateModel UpdateCourse(CourseUpdateModel updateCourse)
        {
            var course = context.Courses.FirstOrDefault(x => x.CourseId == updateCourse.CourseId);
            if (course == null)
            {
                throw new Exception("Course Not Found");
            }

            course.CourseName = updateCourse.CourseName;
            course.StartDate = updateCourse.StartDate;
            context.SaveChanges();

            return new CourseUpdateModel
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                StartDate = course.StartDate,
            };
        }

        public CourseViewModel DeleteCourse(int courseId)
        {
            var course = context.Courses.FirstOrDefault(x => x.CourseId == courseId);
            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
                return new CourseViewModel
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    StartDate = course.StartDate,
                };
            }
            else
            {
                throw new Exception("Course Not Found");
            }
        }
    }
}