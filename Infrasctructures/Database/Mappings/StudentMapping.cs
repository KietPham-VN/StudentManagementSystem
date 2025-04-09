using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.AspNetUser)
                   .WithMany()
                   .HasForeignKey(s => s.AspNetUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}