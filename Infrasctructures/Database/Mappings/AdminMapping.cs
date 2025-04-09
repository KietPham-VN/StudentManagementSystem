using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class AdminMapping : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.AspNetUser)
                   .WithMany()
                   .HasForeignKey(a => a.AspNetUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}