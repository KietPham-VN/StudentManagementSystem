namespace Application.DTOs.CourseStudentDTO
{
    public class CourseStudentCreateModel
    {
        public int CourseId { get; init; }
        public int StudentId { get; init; }
        public float? AssignmentScore { get; init; }
        public float? PracticalScore { get; init; }
        public float? FinalScore { get; init; }
    }
}