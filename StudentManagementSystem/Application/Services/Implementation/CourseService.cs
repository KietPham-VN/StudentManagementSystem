using StudentManagementSystem.Application.DTOs.CourseDTO;
using StudentManagementSystem.Application.Services.Interface;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructures;

namespace StudentManagementSystem.Application.Services.Implementation
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
            return [.. Course.Select(course => new CourseViewModel
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                StartDate = course.StartDate,
            })];
        }

        public async Task<bool> CreateCourse(CreateCourseModel course)
        {
            var newCourse = new Course
            {
                CourseName = course.CourseName,
                StartDate = course.StartDate,
            };
            //await _context.Courses.Add(newCourse);
            //await _context.SaveChanges();
            return true;
        }

        public bool UpdateCourse(UpdateCourseModel updateCourse)
        {
            var course = _context.Courses.FirstOrDefault(x => x.CourseId == updateCourse.CourseId);
            if (course == null)
            {
                return false;
            }
            else
            {
                course.CourseName = updateCourse.CourseName;
                course.StartDate = updateCourse.StartDate;
                _context.SaveChanges();
                return true;
            }
        }

        public bool DeleteCourse(int courseId)
        {
            var course = _context.Courses.FirstOrDefault(x => x.CourseId == courseId);
            if (course == null)
            {
                return false;
            }
            else
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                return true;
            }
        }
    }
}