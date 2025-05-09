namespace Application.DTOs.CourseStudentDTO
{
    public class CourseStudentViewModel
    {
        public int CourseId { get; init; }
        public int StudentId { get; init; }

        public string? CourseName { get; init; }

        [Required]
        public string? StudentName { get; init; }

        public float? AssignmentScore { get; init; }
        public float? PracticalScore { get; init; }
        public float? FinalScore { get; init; }
    }
}