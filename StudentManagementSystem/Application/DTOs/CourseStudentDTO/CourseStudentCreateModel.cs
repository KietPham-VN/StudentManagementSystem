namespace StudentManagementSystem.Application.DTOs.CourseStudentDTO
{
    public class CourseStudentCreateModel
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public float AssignmentScore { get; set; }
        public float PracticalScore { get; set; }
        public float FinalScore { get; set; }
    }
}