using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrasctructures.DatabaseMappings;

namespace StudentManagementSystem.Infrasctructures.Database.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options), IApplicationDbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerQuestion> AnswerQuestions { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<ExamStudent> ExamStudents { get; set; }
        public DbSet<ExamSubmission> ExamSubmissions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSchool> StudentSchools { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<SubmissionAnswer> SubmissionAnswers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<TeacherSchool> TeacherSchools { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                    "Server=KIETPA\\SQLEXPRESS;Database=StudentManagementSystem;Trusted_Connection=True;TrustServerCertificate=True");
            //optionsBuilder.AddInterceptors(
            //    new SqlQueriesLoggingInterceptor(),
            //    new AuditLogInterceptor(),
            //    new AddValueInterceptor(),
            //    new DeleteValueInterceptor()
            //);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminMapping());
            modelBuilder.ApplyConfiguration(new AnswerMapping());
            modelBuilder.ApplyConfiguration(new AnswerQuestionMapping());
            modelBuilder.ApplyConfiguration(new AspNetRoleMapping());
            modelBuilder.ApplyConfiguration(new AspNetUserMapping());
            modelBuilder.ApplyConfiguration(new AspNetUserRoleMapping());
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new CourseStudentMapping());
            modelBuilder.ApplyConfiguration(new ExamMapping());
            modelBuilder.ApplyConfiguration(new ExamQuestionMapping());
            modelBuilder.ApplyConfiguration(new ExamStudentMapping());
            modelBuilder.ApplyConfiguration(new ExamSubmissionMapping());
            modelBuilder.ApplyConfiguration(new QuestionMapping());
            modelBuilder.ApplyConfiguration(new SchoolMapping());
            modelBuilder.ApplyConfiguration(new StudentMapping());
            modelBuilder.ApplyConfiguration(new StudentSchoolMapping());
            modelBuilder.ApplyConfiguration(new SubmissionMapping());
            modelBuilder.ApplyConfiguration(new SubmissionAnswerMapping());
            modelBuilder.ApplyConfiguration(new TeacherMapping());
            modelBuilder.ApplyConfiguration(new TeacherCourseMapping());
            modelBuilder.ApplyConfiguration(new TeacherSchoolMapping());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}