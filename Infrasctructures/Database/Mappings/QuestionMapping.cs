using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class QuestionMapping : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Content).IsRequired();
            builder.Property(q => q.Score).HasColumnType("decimal(5,2)");
            builder.Property(q => q.QuestionType).HasConversion<int>();
        }
    }
}