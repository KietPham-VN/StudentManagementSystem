using StudentManagementSystem.Application.Services.Interface;

namespace StudentManagementSystem.Application.Services.Implementation
{
    public class CacheService : ICacheService
    {
        private Dictionary<string, CacheData> _cache = new();
        public CacheData Get(string key)
        {
            if (!_cache.ContainsKey(key))
            {
                return null;
            }
            var cacheData = _cache[key];
            if (cacheData.Expiration < DateTime.Now)
            {
                _cache.Remove(key);
                return null;
            }
            return cacheData;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Set(string key, object value, int duration)
        {
            CacheData cacheData = new(value, DateTime.Now.AddSeconds(duration));
            _cache[key] = cacheData;
        }
    }
}
