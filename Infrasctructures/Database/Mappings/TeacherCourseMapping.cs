using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class TeacherCourseMapping : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherCourse> builder)
        {
            builder.ToTable("TeacherCourses");

            // Composite Primary Key
            builder.HasKey(tc => new { tc.TeacherId, tc.CourseId });

            // Quan hệ với Teacher
            builder.HasOne(tc => tc.Teacher)
                   .WithMany(t => t.TeacherCourses)
                   .HasForeignKey(tc => tc.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ với Course
            builder.HasOne(tc => tc.Course)
                   .WithMany(c => c.TeacherCourses)
                   .HasForeignKey(tc => tc.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}