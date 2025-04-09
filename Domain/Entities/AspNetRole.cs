using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystem.Domain.Entities
{
    public class AspNetRole : IdentityRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public ICollection<AspNetUserRole> UserRoles { get; set; }
    }
}