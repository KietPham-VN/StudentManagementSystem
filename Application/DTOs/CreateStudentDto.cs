using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Application.DTOs
{
    public class CreateStudentDto
    {
        [Required]
        public string AspNetUserId { get; set; } = string.Empty;
    }
}