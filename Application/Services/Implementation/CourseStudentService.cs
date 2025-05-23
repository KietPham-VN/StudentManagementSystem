﻿using Application.DTOs.CourseStudentDTO;
using Application.Services.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementation
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
                AssignmentScore = courseStudentEntity.AssignmentScore,
                PracticalScore = courseStudentEntity.PracticalScore,
                FinalScore = courseStudentEntity.FinalScore
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
            _context.SaveChanges();
            return new CourseStudentUpdateModel
            {
                CourseId = courseStudent.CourseId,
                StudentId = courseStudent.StudentId,
                AssignmentScore = courseStudent.AssignmentScore ?? 0,
                PracticalScore = courseStudent.PracticalScore ?? 0,
                FinalScore = courseStudent.FinalScore ?? 0
            };
        }

        public IEnumerable<CourseStudentViewModel> GetScoresByStudent(int studentId)
        {
            var courseStudent = _context.CourseStudents
                .Include(cs => cs.Course)
                .Where(cs => cs.StudentId == studentId)
                .Select(cs => new CourseStudentViewModel
                {
                    CourseId = cs.CourseId,
                    StudentId = cs.StudentId,
                    CourseName = cs.Course.CourseName,
                    StudentName = cs.Student.FirstName + " " + cs.Student.LastName,
                    AssignmentScore = cs.AssignmentScore,
                    PracticalScore = cs.PracticalScore,
                    FinalScore = cs.FinalScore
                }).ToList();
            return courseStudent;
        }

        public float GetAverageScore(int studentId)
        {
            var scores = _context.CourseStudents.Where(cs => cs.StudentId == studentId)
                .Select(cs => (cs.AssignmentScore + cs.PracticalScore + cs.FinalScore) / 3f)
                .ToList();
            if (scores.Count == 0) return 0;

            return (float)scores.Average();
        }
    }
}