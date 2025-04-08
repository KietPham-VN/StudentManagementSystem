namespace StudentManagementSystem.Domain.Entities
{
    public class TeacherSchool
    {
        public int TeacherId { get; set; }
        public int SchoolId { get; set; }

        public Teacher Teacher { get; set; }
        public School School { get; set; }
    }
}