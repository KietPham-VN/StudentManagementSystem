namespace Domain.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string? SchoolName { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
    }
}