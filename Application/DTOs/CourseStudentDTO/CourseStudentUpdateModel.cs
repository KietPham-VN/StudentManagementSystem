namespace Application.DTOs.CourseStudentDTO
{
    public class CourseStudentUpdateModel
    {
        public int CourseId { get; init; }
        public int StudentId { get; init; }
        public float AssignmentScore { get; init; }
        public float PracticalScore { get; init; }
        public float FinalScore { get; init; }
    }
}