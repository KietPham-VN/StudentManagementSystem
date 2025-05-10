namespace Domain.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<School> Schools { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<CourseStudent> CourseStudents { get; set; }
        DbSet<User> Users { get; set; }

        EntityEntry<T> Entity<T>(T entity) where T : class;

        int SaveChanges();

        public Task<int> SaveChangesAsync();
    }
}