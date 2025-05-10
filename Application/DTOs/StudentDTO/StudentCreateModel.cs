namespace Application.DTOs.StudentDTO
{
    public class StudentCreateModel
    {
        public int? Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Address { get; set; }

        public int SchoolId { get; set; }
    }

    public class Address
    {
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
    }
}