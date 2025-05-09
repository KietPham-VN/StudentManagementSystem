namespace Application.DTOs.SchoolDTO
{
    public class SchoolCreateModel
    {
        public int SchoolId { get; set; }

        [Required]
        public string? SchoolName { get; init; }

        public string? Address { get; init; }
    }
}