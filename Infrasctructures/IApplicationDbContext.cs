using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures
{
    public interface IApplicationDbContext
    {
        DbSet<Admin> Students { get; set; }
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
        DbSet<Student> Student { get; set; }
        DbSet<StudentSchool> StudentSchools { get; set; }
        DbSet<Submission> Submissions { get; set; }
        DbSet<SubmissionAnswer> SubmissionAnswers { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<TeacherSchool> TeacherSchools { get; set; }
    }
}