namespace StudentManagementSystem.Application.Services.Implementation
{
    public class CacheData(object value, DateTime expiration)
    {
        public object Value { get; set; } = value;
        public DateTime Expiration { get; set; } = expiration;
    }
}
