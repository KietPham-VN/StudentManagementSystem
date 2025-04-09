using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class TeacherSchoolMapping : IEntityTypeConfiguration<TeacherSchool>
    {
        public void Configure(EntityTypeBuilder<TeacherSchool> builder)
        {
            builder.ToTable("TeacherSchools");
            builder.HasKey(ts => new { ts.TeacherId, ts.SchoolId });

            builder.HasOne(ts => ts.Teacher)
                   .WithMany(t => t.TeacherSchools)
                   .HasForeignKey(ts => ts.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ts => ts.School)
                   .WithMany(sch => sch.TeacherSchools)
                   .HasForeignKey(ts => ts.SchoolId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}