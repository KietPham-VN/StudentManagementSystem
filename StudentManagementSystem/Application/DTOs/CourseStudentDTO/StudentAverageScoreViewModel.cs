namespace StudentManagementSystem.Application.DTOs.CourseStudentDTO
{
    public class StudentAverageScoreViewModel
    {
        public int StudentId { get; set; }
        public int CourseCount { get; set; }
        public float AverageScore { get; set; }
    }
}