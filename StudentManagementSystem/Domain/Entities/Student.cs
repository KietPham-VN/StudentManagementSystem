namespace StudentManagementSystem.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int SchoolId { get; set; }
        public virtual School? School { get; set; }

        //Virtual: là thuộc tính có thể được ghi đè trong lớp con.
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
    }
}