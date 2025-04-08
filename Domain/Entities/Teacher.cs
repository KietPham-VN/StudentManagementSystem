namespace StudentManagementSystem.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }

        public AspNetUser AspNetUser { get; set; }
        public ICollection<TeacherSchool> TeacherSchools { get; set; }
    }
}