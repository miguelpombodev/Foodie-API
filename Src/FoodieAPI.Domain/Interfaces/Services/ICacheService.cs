namespace FoodieAPI.Domain.Interfaces.Services;

public interface ICacheService
{
    T? GetData<T>(string key);
    void SetData<T>(string key, T data);
}