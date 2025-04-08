namespace StudentManagementSystem.Domain.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }

        public ICollection<AnswerQuestion> AnswerQuestions { get; set; }
    }
}