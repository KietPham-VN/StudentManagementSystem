namespace StudentManagementSystem.Application.DTOs.CourseStudentDTO
{
    public class CourseScoreViewModel
    {
        public string CourseName { get; set; }
        public float AssignmentScore { get; set; }
        public float PracticalScore { get; set; }
        public float FinalScore { get; set; }
    }
}