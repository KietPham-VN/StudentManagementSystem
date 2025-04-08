using StudentManagementSystem.Domain.Enums;

namespace StudentManagementSystem.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public QuestionType QuestionType { get; set; }
        public decimal Score { get; set; }

        public ICollection<AnswerQuestion> AnswerQuestions { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<SubmissionAnswer> SubmissionAnswers { get; set; }
    }
}