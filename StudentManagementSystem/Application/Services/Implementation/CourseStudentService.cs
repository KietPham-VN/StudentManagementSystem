using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.DTOs.CourseStudentDTO;
using StudentManagementSystem.Application.Services.Interface;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructures;

namespace StudentManagementSystem.Application.Services.Implementation
{
    public class CourseStudentService(IApplicationDbContext _context) : ICourseStudentService
    {
        public CourseStudentViewModel GetCourseStudents(int? courseId, int? studentId)
        {
            var query = _context.CourseStudents
               .Include(cs => cs.Course)
               .Include(cs => cs.Student)
               .AsQueryable();

            if (courseId is not null)
                query = query.Where(cs => cs.CourseId == courseId);

            if (studentId is not null)
                query = query.Where(cs => cs.StudentId == studentId);

            var result = query.Select(cs => new CourseStudentViewModel
            {
                CourseId = cs.CourseId,
                StudentId = cs.StudentId,
                CourseName = cs.Course.CourseName,
                StudentName = cs.Student.FirstName + " " + cs.Student.LastName,
                AssignmentScore = cs.AssignmentScore,
                PracticalScore = cs.PracticalScore,
                FinalScore = cs.FinalScore
            }).FirstOrDefault();
            if (result == null)
            {
                throw new KeyNotFoundException("Not Found CourseId / StudentId!");
            }
            return result;
        }

        public CourseStudentCreateModel CreateCourseStudent(CourseStudentCreateModel courseStudent)
        {
            var courseStudentEntity = new CourseStudent
            {
                CourseId = courseStudent.CourseId,
                StudentId = courseStudent.StudentId,
                AssignmentScore = courseStudent.AssignmentScore,
                PracticalScore = courseStudent.PracticalScore,
                FinalScore = courseStudent.FinalScore
            };

            _context.CourseStudents.Add(courseStudentEntity);
            _context.SaveChanges();

            return new CourseStudentCreateModel
            {
                CourseId = courseStudentEntity.CourseId,
                StudentId = courseStudentEntity.StudentId,
                AssignmentScore = courseStudentEntity.AssignmentScore ?? 0,
                PracticalScore = courseStudentEntity.PracticalScore ?? 0,
                FinalScore = courseStudentEntity.FinalScore ?? 0
            };
        }

        public CourseStudentUpdateModel UpdateCourseStudent(int courseId, int studentId, CourseStudentUpdateModel updateCourseStudent)
        {
            var courseStudent = _context.CourseStudents
                .FirstOrDefault(cs => cs.CourseId == courseId && cs.StudentId == studentId);
            if (courseStudent != null)
            {
                courseStudent.AssignmentScore = updateCourseStudent.AssignmentScore;
                courseStudent.PracticalScore = updateCourseStudent.PracticalScore;
                courseStudent.FinalScore = updateCourseStudent.FinalScore;
            }
            else
            {
                throw new KeyNotFoundException("Not Found CourseId / StudentId!");
            }
            return new CourseStudentUpdateModel
            {
                CourseId = courseStudent.CourseId,
                StudentId = courseStudent.StudentId,
                AssignmentScore = courseStudent.AssignmentScore ?? 0,
                PracticalScore = courseStudent.PracticalScore ?? 0,
                FinalScore = courseStudent.FinalScore ?? 0
            };
        }

        public IEnumerable<CourseScoreViewModel> GetScoresByStudent(int studentId)
        {
            var scores = _context.CourseStudents
                .Where(cs => cs.StudentId == studentId)
                .Include(cs => cs.Course)
                .Select(cs => new CourseScoreViewModel
                {
                    CourseName = cs.Course.CourseName,
                    AssignmentScore = (float)cs.AssignmentScore,
                    PracticalScore = (float)cs.PracticalScore,
                    FinalScore = (float)cs.FinalScore
                }).ToList();
            return scores;
        }

        public float GetAverageScore(int studentId)
        {
            var scores = _context.CourseStudents.Where(cs => cs.StudentId == studentId)
                .Select(cs => (cs.AssignmentScore + cs.PracticalScore + cs.FinalScore) / 3f)
                .ToList();
            if (scores.Count == 0) return 0;

            return (float)scores.Average();
        }

        public bool RegisterCourse(RegisterCourseModel registerCourse)
        {
            var exists = _context.CourseStudents.Any(cs =>
                cs.StudentId == registerCourse.StudentId &&
                cs.CourseId == registerCourse.CourseId);

            if (exists)
                return false;

            var newEntry = new CourseStudent
            {
                StudentId = registerCourse.StudentId,
                CourseId = registerCourse.CourseId,
                AssignmentScore = null,
                PracticalScore = null,
                FinalScore = null
            };

            _context.CourseStudents.Add(newEntry);
            return _context.SaveChanges() > 0;
        }
    }
}