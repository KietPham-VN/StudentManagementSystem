using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class ExamSubmissionMapping : IEntityTypeConfiguration<ExamSubmission>
    {
        public void Configure(EntityTypeBuilder<ExamSubmission> builder)
        {
            builder.ToTable("ExamSubmissions");
            builder.HasKey(es => new { es.ExamId, es.SubmissionId, es.StudentId });

            builder.HasOne(es => es.Exam)
                   .WithMany(e => e.ExamSubmissions)
                   .HasForeignKey(es => es.ExamId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(es => es.Submission)
                   .WithMany(s => s.ExamSubmissions)
                   .HasForeignKey(es => es.SubmissionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(es => es.Student)
                   .WithMany(s => s.ExamSubmissions)
                   .HasForeignKey(es => es.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}