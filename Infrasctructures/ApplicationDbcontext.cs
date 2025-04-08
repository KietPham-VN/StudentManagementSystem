using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options), IApplicationDbContext
    {
        public DbSet<Admin> Students { get; set; }
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
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentSchool> StudentSchools { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<SubmissionAnswer> SubmissionAnswers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSchool> TeacherSchools { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                    "Server=KIETPA\\SQLEXPRESS;Database=StudentManagement;Trusted_Connection=True;TrustServerCertificate=True");
            //optionsBuilder.AddInterceptors(
            //    new SqlQueriesLoggingInterceptor(),
            //    new AuditLogInterceptor(),
            //    new AddValueInterceptor(),
            //    new DeleteValueInterceptor()
            //);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new StudentMapping());
        //    modelBuilder.ApplyConfiguration(new SchoolMapping());
        //    modelBuilder.ApplyConfiguration(new CourseMapping());
        //    modelBuilder.ApplyConfiguration(new CourseStudentMapping());
        //    modelBuilder.Entity<Course>().HasQueryFilter(p => !p.IsDeleted);

        //    base.OnModelCreating(modelBuilder);
        //}

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}