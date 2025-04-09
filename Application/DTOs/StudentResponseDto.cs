using System.Text.Json.Serialization;

namespace StudentManagementSystem.Application.DTOs
{
    public class StudentResponseDto
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; } = string.Empty;

        [JsonIgnore]
        public string FirstName { get; set; } = string.Empty;

        [JsonIgnore]
        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string FullName => $"{FirstName} {LastName}".Trim();

        public int Age => DateTime.Today.Year - DateOfBirth.Year -
            (DateTime.Today.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
    }
}