using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrasctructures.Database.Mappings
{
    public class AspNetUserRoleMapping : IEntityTypeConfiguration<AspNetUserRole>
    {
        public void Configure(EntityTypeBuilder<AspNetUserRole> builder)
        {
            builder.ToTable("AspNetUserRoles");
            builder.HasKey(ur => new { ur.AspNetUserId, ur.AspNetRoleId });

            builder.HasOne(ur => ur.AspNetUser)
                   .WithMany(u => u.UserRoles)
                   .HasForeignKey(ur => ur.AspNetUserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ur => ur.AspNetRole)
                   .WithMany(r => r.UserRoles)
                   .HasForeignKey(ur => ur.AspNetRoleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}