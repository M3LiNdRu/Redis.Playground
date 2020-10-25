using System;
using System.Threading.Tasks;

namespace Redis.Playground
{
    public interface IRedisRepository
    {
        Task<string> GetString(string key);
        Task SetString(string key, string value);
    }
}
