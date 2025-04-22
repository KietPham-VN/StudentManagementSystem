namespace StudentManagementSystem.Application.DTOs.CourseDTO
{
    public class CreateCourseModel
    {
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
    }
}