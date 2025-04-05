namespace StudentManagementSystem.Domain.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public Course Course { get; set; }
    }
}