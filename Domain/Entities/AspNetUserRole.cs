namespace StudentManagementSystem.Domain.Entities
{
    public class AspNetUserRole
    {
        public string AspNetUserId { get; set; }
        public string AspNetRoleId { get; set; }

        public AspNetUser AspNetUser { get; set; }
        public AspNetRole AspNetRole { get; set; }
    }
}