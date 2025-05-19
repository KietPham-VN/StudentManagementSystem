using Domain.Abstractions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace Infrastructures.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : DbContext(options), IApplicationDbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<School> Schools { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseStudent> CourseStudents { get; set; }
    public DbSet<User> Users { get; set; }

    public EntityEntry<T> Entity<T>(T entity) where T : class
    {
        return base.Entry(entity);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentMapping());
        modelBuilder.ApplyConfiguration(new SchoolMapping());
        modelBuilder.ApplyConfiguration(new CourseMapping());
        modelBuilder.ApplyConfiguration(new StudentCourseMapping());
        modelBuilder.ApplyConfiguration(new UserMapping());
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        Console.WriteLine("SaveChanges");
        return base.SaveChanges();
    }

    public Task<int> SaveChangesAsync()
    {
        Console.WriteLine("SaveChanges");

        return base.SaveChangesAsync();
    }
}