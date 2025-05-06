namespace Application.DTOs.SchoolDTO
{
    public class SchoolCreateModel
    {
        public int SchoolId { get; set; }

        [Required]
        public string? SchoolName { get; set; }

        public string? Address { get; set; }
    }
}