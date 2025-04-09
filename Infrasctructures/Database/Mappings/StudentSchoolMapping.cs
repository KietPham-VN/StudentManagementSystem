using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class StudentSchoolMapping : IEntityTypeConfiguration<StudentSchool>
    {
        public void Configure(EntityTypeBuilder<StudentSchool> builder)
        {
            builder.ToTable("StudentSchools");
            builder.HasKey(ss => new { ss.StudentId, ss.SchoolId });

            builder.HasOne(ss => ss.Student)
                   .WithMany(s => s.StudentSchools)
                   .HasForeignKey(ss => ss.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ss => ss.School)
                   .WithMany(sch => sch.StudentSchools)
                   .HasForeignKey(ss => ss.SchoolId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}