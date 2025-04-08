namespace StudentManagementSystem.Domain.Entities
{
    public class ExamSubmission
    {
        public int ExamId { get; set; }
        public int SubmissionId { get; set; }
        public int StudentId { get; set; }

        public Exam Exam { get; set; }
        public Submission Submission { get; set; }
        public Student Student { get; set; }
    }
}