using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class ExamQuestionMapping : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.ToTable("ExamQuestions");
            builder.HasKey(eq => new { eq.ExamId, eq.QuestionId });
            builder.HasOne(eq => eq.Exam)
                   .WithMany(e => e.ExamQuestions)
                   .HasForeignKey(eq => eq.ExamId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(eq => eq.Question)
                   .WithMany(q => q.ExamQuestions)
                   .HasForeignKey(eq => eq.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}