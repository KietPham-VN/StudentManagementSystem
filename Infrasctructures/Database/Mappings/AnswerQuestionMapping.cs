using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class AnswerQuestionMapping : IEntityTypeConfiguration<AnswerQuestion>
    {
        public void Configure(EntityTypeBuilder<AnswerQuestion> builder)
        {
            builder.ToTable("AnswerQuestions");
            builder.HasKey(aq => new { aq.AnswerId, aq.QuestionId });
            builder
                .HasOne(aq => aq.Answer)
                .WithMany(a => a.AnswerQuestions)
                .HasForeignKey(aq => aq.AnswerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(aq => aq.Question)
                .WithMany(q => q.AnswerQuestions)
                .HasForeignKey(aq => aq.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}