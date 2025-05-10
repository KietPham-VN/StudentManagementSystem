using Application.Services.Interface;

namespace Application.Services.Implementation
{
    public class CacheService : ICacheService
    {
        private readonly Dictionary<string, CacheData> _cache = [];

        public CacheData? Get(string key)
        {
            if (!_cache.TryGetValue(key, out var cacheData))
            {
                return null;
            }

            if (cacheData.Expiration >= DateTime.Now) return cacheData;
            _cache.Remove(key);
            return null;
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