using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystem.Domain.Entities
{
    public class AspNetRole : IdentityRole
    {
        public ICollection<AspNetUserRole> UserRoles { get; set; }
    }
}