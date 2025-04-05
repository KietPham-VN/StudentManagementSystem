namespace StudentManagementSystem.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Exam Exam { get; set; }

        public Question()
        {
            CreatedAt = DateTime.Now;
        }
    }
}