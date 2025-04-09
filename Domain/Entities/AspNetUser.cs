using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystem.Domain.Entities
{
    public class AspNetUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<AspNetUserRole> UserRoles { get; set; }
    }
}