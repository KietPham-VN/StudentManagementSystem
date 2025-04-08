namespace StudentManagementSystem.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public ICollection<CourseStudent> CourseStudents { get; set; }
    }
}