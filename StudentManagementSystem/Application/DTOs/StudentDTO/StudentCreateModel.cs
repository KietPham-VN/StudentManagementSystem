using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Application.DTOs.StudentDTO
{
    public class StudentCreateModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "This Field is required!!!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This Field is required!!!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This Field is required!!!")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "This Field is required!!!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This Field is required!!!")]
        public int SchoolId { get; set; }
    }
}