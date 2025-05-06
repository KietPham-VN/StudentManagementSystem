namespace Domain.Entities
{
    public class CourseStudent
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Course? Course { get; set; }
        public Student? Student { get; set; }
        public float? AssignmentScore { get; set; }
        public float? PracticalScore { get; set; }
        public float? FinalScore { get; set; }
    }
}