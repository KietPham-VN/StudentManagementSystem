namespace StudentManagementSystem.Domain.Entities
{
    public class SubmissionAnswer
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int QuestionId { get; set; }

        public int? SelectedAnswerId { get; set; }
        public string EssayAnswer { get; set; }
        public decimal Score { get; set; }

        public Submission Submission { get; set; }
        public Question Question { get; set; }
        public Answer SelectedAnswer { get; set; }
    }
}