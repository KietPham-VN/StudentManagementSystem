namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin,
        Teacher,
        Student
    }
}