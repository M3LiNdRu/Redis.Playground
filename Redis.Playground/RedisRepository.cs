using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Redis.Playground
{
    public class RedisRepository : IRedisRepository
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect("localhost:6379");
        });

        public static ConnectionMultiplexer Connection => lazyConnection.Value;

        public RedisRepository()
        {
        }

        async Task<string> IRedisRepository.GetString(string key)
        {
            return await Connection.GetDatabase().StringGetAsync(key);
        }

        async Task IRedisRepository.SetString(string key, string value)
        {
            await Connection.GetDatabase().StringSetAsync(key, value, TimeSpan.FromMinutes(1));
        }
    }
}
