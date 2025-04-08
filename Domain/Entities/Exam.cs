namespace StudentManagementSystem.Domain.Entities
{
    public class Exam
    {
        public int Id { get; set; }

        public ICollection<ExamStudent> ExamStudents { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<ExamSubmission> ExamSubmissions { get; set; }
    }
}