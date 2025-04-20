namespace StudentManagementSystem.Application.DTOs.CourseStudentDTO
{
    public class CourseStudentViewModel
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string CourseName { get; set; }
        public string StudentName { get; set; }
        public float? AssignmentScore { get; set; }
        public float? PracticalScore { get; set; }
        public float? FinalScore { get; set; }
    }
}

////