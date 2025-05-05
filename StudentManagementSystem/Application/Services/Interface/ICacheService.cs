using StudentManagementSystem.Application.Services.Implementation;

namespace StudentManagementSystem.Application.Services.Interface
{
    public interface ICacheService
    {
        CacheData Get(string key);
        public void Set(string key, object value, int duration);
        public void Remove(string key);
    }
}
