using Application.DTOs.CourseDTO;
using Application.Services.Interface;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Implementation
{
    public class CourseService(IApplicationDbContext _context) : ICourseService
    {
        public IEnumerable<CourseViewModel> GetCourses(int? CourseId)
        {
            var Course = _context.Courses.AsQueryable();
            if (CourseId.HasValue)
            {
                Course = Course.Where(school => school.CourseId == CourseId);
            }
            if (Course.IsNullOrEmpty())
            {
                throw new Exception("Course Not Found");
            }
            return [.. Course.Select(course => new CourseViewModel
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
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return new CreateCourseModel
            {
                CourseId = newCourse.CourseId,
                CourseName = newCourse.CourseName,
                StartDate = newCourse.StartDate,
            };
        }

        public CourseUpdateModel UpdateCourse(CourseUpdateModel updateCourse)
        {
            var course = _context.Courses.FirstOrDefault(x => x.CourseId == updateCourse.CourseId);
            if (course == null)
            {
                throw new Exception("Course Not Found");
            }

            course.CourseName = updateCourse.CourseName;
            course.StartDate = updateCourse.StartDate;
            _context.SaveChanges();

            return new CourseUpdateModel
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                StartDate = course.StartDate,
            };
        }

        public CourseViewModel DeleteCourse(int courseId)
        {
            var course = _context.Courses.FirstOrDefault(x => x.CourseId == courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
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