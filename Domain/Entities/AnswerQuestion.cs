namespace StudentManagementSystem.Domain.Entities
{
    public class AnswerQuestion
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }

        public Answer Answer { get; set; }
        public Question Question { get; set; }
    }
}