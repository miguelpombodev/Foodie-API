using FoodieAPI.Domain.Interfaces.Services;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FoodieAPI.Services.Implementations;

public class CacheService: ICacheService
{
    private readonly IDistributedCache? _cache;

    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }
    
    public T? GetData<T>(string key)
    {
       var data = _cache.GetString(key);
       if (data is null)
           return default(T);

       return JsonConvert.DeserializeObject<T>(data);
    }

    public void SetData<T>(string key, T data)
    {
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };
        
        _cache.SetString(key, JsonConvert.SerializeObject(data), options);
    }
}