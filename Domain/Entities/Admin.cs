namespace StudentManagementSystem.Domain.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }

        public AspNetUser AspNetUser { get; set; }
    }
}