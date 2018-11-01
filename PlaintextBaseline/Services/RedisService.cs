using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace PlaintextBaseline.Services
{
    public class RedisService
    {
        public static RedisService Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private static Lazy<RedisService> _instance = new Lazy<RedisService>(() =>
        {
            return new RedisService();
        });

        private RedisService()
        {
            string connStr = ConfigurationManager.AppSettings["RedisConnectionString"];
            Redis = ConnectionMultiplexer.Connect(connStr);
            database = Redis.GetDatabase();
        }

        private ConnectionMultiplexer Redis = null;
        private IDatabase database = null;

        public T Get<T>(string key)
        {
            var value = default(T);
            if(string.IsNullOrEmpty(key))
            {
                return value;
            }
            string str = database.StringGet(key);
            if(!string.IsNullOrEmpty(str))
            {
                value = JsonConvert.DeserializeObject<T>(str);
            }
            return value;
        }

        public bool Set(string key, object value, TimeSpan? timeToLive)
        {
            if(string.IsNullOrEmpty(key) || value == null)
            {
                return false;
            }
            string str = JsonConvert.SerializeObject(value);
            return database.StringSet(key, str, timeToLive);
        }

        public async Task<T> GetAsync<T>( string key)
        {
            var value = default(T);
            if (string.IsNullOrEmpty(key))
            {
                return value;
            }
            string str = await database.StringGetAsync(key);
            if (!string.IsNullOrEmpty(str))
            {
                value = JsonConvert.DeserializeObject<T>(str);
            }
            return value;
        }

        public async Task<bool> SetAsync(string key, object value, TimeSpan? timeToLive)
        {
            if (string.IsNullOrEmpty(key) || value == null)
            {
                return false;
            }
            string str = JsonConvert.SerializeObject(value);
            return await database.StringSetAsync(key, str, timeToLive);
        }
    }
}