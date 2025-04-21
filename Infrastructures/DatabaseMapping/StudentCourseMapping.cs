using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrastructures.DatabaseMapping
{
    public class StudentCourseMapping : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {
            builder.ToTable("CourseStudents"); // Tên bảng trong database
            builder.HasKey(cs => new { cs.StudentId, cs.CourseId }); // Khóa chính là sự kết hợp của StudentId và CourseId

            builder.HasOne(cs => cs.Student)
                .WithMany(s => s.CourseStudents)
                .HasForeignKey(cs => cs.StudentId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa sinh viên thì sẽ xóa tất cả các khóa học của sinh viên đó

            builder.HasOne(cs => cs.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(cs => cs.CourseId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa khóa học thì sẽ xóa tất cả các sinh viên thuộc khóa học đó
        }
    }
}