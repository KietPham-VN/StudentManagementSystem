using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class SubmissionAnswerMapping : IEntityTypeConfiguration<SubmissionAnswer>
    {
        public void Configure(EntityTypeBuilder<SubmissionAnswer> builder)
        {
            builder.ToTable("SubmissionAnswers");
            builder.HasKey(sa => sa.Id);

            builder.Property(sa => sa.Score).HasColumnType("decimal(5,2)");

            builder.HasOne(sa => sa.Submission)
                   .WithMany(s => s.SubmissionAnswers)
                   .HasForeignKey(sa => sa.SubmissionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sa => sa.Question)
                   .WithMany(q => q.SubmissionAnswers)
                   .HasForeignKey(sa => sa.QuestionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sa => sa.SelectedAnswer)
                   .WithMany()
                   .HasForeignKey(sa => sa.SelectedAnswerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}