namespace StudentManagementSystem.Domain.Entities
{
    public class StudentSchool
    {
        public int StudentId { get; set; }
        public int SchoolId { get; set; }

        public Student Student { get; set; }
        public School School { get; set; }
    }
}