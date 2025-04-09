using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class CourseStudentMapping : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {
            builder.ToTable("CourseStudents");
            builder.HasKey(cs => new { cs.CourseId, cs.StudentId });
            builder.HasOne(cs => cs.Course)
                   .WithMany(c => c.CourseStudents)
                   .HasForeignKey(cs => cs.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(cs => cs.Student)
                   .WithMany(s => s.CourseStudents)
                   .HasForeignKey(cs => cs.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}