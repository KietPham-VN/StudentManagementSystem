namespace StudentManagementSystem.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
    }
}