using Application.Services.Implementation;

namespace Application.Services.Interface
{
    public interface ICacheService
    {
        CacheData? Get(string key);

        public void Set(string key, object value, int duration);

        public void Remove(string key);
    }
}