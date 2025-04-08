namespace StudentManagementSystem.Domain.Entities
{
    public class Submission
    {
        public int Id { get; set; }
        public DateTime SubmittedAt { get; set; }

        public ICollection<SubmissionAnswer> SubmissionAnswers { get; set; }
        public ICollection<ExamSubmission> ExamSubmissions { get; set; }
    }
}