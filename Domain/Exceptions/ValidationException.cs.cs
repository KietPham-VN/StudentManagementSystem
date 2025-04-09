namespace StudentManagementSystem.Domain.Exceptions
{
    public class ValidationException(string message, string propertyName) : Exception($"{propertyName}: {message}")
    {
        public string PropertyName { get; } = propertyName;
    }
}