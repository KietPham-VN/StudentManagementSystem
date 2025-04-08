namespace StudentManagementSystem.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }

        public AspNetUser AspNetUser { get; set; }
        public ICollection<StudentSchool> StudentSchools { get; set; }
        public ICollection<CourseStudent> CourseStudents { get; set; }
        public ICollection<ExamStudent> ExamStudents { get; set; }
        public ICollection<ExamSubmission> ExamSubmissions { get; set; }
    }
}