using System.Text.RegularExpressions;

namespace StudentManagementSystem.Application.Services
{
    public class StudentValidationService
    {
        public bool IsValidAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth > today.AddYears(-age)) age--;

            return age >= 18;
        }

        public bool IsValidName(string name)
        {
            // Chỉ cho chữ và khoảng trắng
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }
    }
}