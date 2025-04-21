using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrastructures.DatabaseMapping
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students"); // Tên bảng trong database
            builder.HasKey(s => s.Id); // Khóa chính

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd(); // Tự động tăng

            builder.Property(x => x.FirstName)
                .HasColumnName("SurName")
                .HasMaxLength(255); // Tên sinh viên có độ dài là 255
            builder.Property(x => x.LastName)
                .HasMaxLength(255);

            builder.Property(x => x.DateOfBirth)
                .IsRequired(); // bắt buộc nhập ngày sinh

            builder.Property(x => x.Address);

            //Thiết lập mỗi quan hệ 1 - N với School
            builder.HasOne(x => x.School)
                 .WithMany(s => s.Students)
                 .HasForeignKey(x => x.SchoolId)
                 .OnDelete(DeleteBehavior.Cascade); // Khi xóa trường học thì sẽ xóa tất cả sinh viên thuộc trường đó
            builder.HasMany(x => x.CourseStudents)
                .WithOne(cs => cs.Student)
                .HasForeignKey(cs => cs.StudentId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa sinh viên thì sẽ xóa tất cả các khóa học của sinh viên đó
        }
    }
}