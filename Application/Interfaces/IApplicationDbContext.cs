using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Admin> Admins { get; set; }
        DbSet<Answer> Answers { get; set; }
        DbSet<AnswerQuestion> AnswerQuestions { get; set; }
        DbSet<AspNetRole> AspNetRoles { get; set; }
        DbSet<AspNetUser> AspNetUsers { get; set; }
        DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<CourseStudent> CourseStudents { get; set; }
        DbSet<Exam> Exams { get; set; }
        DbSet<ExamQuestion> ExamQuestions { get; set; }
        DbSet<ExamStudent> ExamStudents { get; set; }
        DbSet<ExamSubmission> ExamSubmissions { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<School> Schools { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<StudentSchool> StudentSchools { get; set; }
        DbSet<Submission> Submissions { get; set; }
        DbSet<SubmissionAnswer> SubmissionAnswers { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<TeacherCourse> TeacherCourses { get; set; }
        DbSet<TeacherSchool> TeacherSchools { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}