using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class ExamStudentMapping : IEntityTypeConfiguration<ExamStudent>
    {
        public void Configure(EntityTypeBuilder<ExamStudent> builder)
        {
            builder.ToTable("ExamStudents");
            builder.HasKey(es => new { es.ExamId, es.StudentId });
            builder.HasOne(es => es.Exam)
                   .WithMany(e => e.ExamStudents)
                   .HasForeignKey(es => es.ExamId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(es => es.Student)
                   .WithMany(s => s.ExamStudents)
                   .HasForeignKey(es => es.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}