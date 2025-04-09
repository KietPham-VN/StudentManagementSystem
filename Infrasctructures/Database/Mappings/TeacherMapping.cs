using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class TeacherMapping : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.AspNetUser)
                   .WithMany()
                   .HasForeignKey(t => t.AspNetUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}