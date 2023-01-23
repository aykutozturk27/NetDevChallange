using Microsoft.Extensions.Configuration;
using NetDevChallange.Core.Utilities.Configuration;
using StackExchange.Redis;
using System.Text.Json;

namespace NetDevChallange.Core.DataAccess.Redis
{
    public class RedisBaseRepository : IRedisBaseRepository
    {
        private ConfigurationOptions _configurationOptions;
        private IConfiguration _configuration;

        public RedisBaseRepository()
        {
            _configuration = CoreConfig.GetConfiguration();
            _configurationOptions = new ConfigurationOptions
            {
                EndPoints = { $"{_configuration.GetValue<string>("Redis:Host")}:{_configuration.GetValue<int>("Redis:Port")}" },
                User = $"{_configuration.GetValue<string>("Redis:User")}",
                Password = $"{_configuration.GetValue<string>("Redis:Password")}",
                Ssl = _configuration.GetValue<bool>("Redis:Ssl"),
                AbortOnConnectFail = false,
            };
        }

        public T? Get<T>(string key, int db = 0)
        {
            using (var connection = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                IDatabase database = connection.GetDatabase(db);
                if (Any(key, db))
                {
                    string jsonData = database.StringGet(key);
                    var data = JsonSerializer.Deserialize<T>(jsonData);
                    return data;
                }
            }
            return default;
        }

        public void Set(string key, object data, double duration = 0, int db = 0)
        {
            using (var connection = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                IDatabase database = connection.GetDatabase(db);

                string jsonData = JsonSerializer.Serialize(data);
                database.StringSet(key, jsonData, TimeSpan.FromMinutes((double)duration));
            }
        }

        public void Set<T>(string key, T data, double duration = 0, int db = 0) where T : class
        {
            using (var connection = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                IDatabase database = connection.GetDatabase(db);

                string jsonData = JsonSerializer.Serialize(data);
                database.StringSet(key, jsonData, TimeSpan.FromMinutes((double)duration));
            }
        }

        public void Set(KeyValuePair<RedisKey, RedisValue>[] keyValue, double duration = 0, int db = 0)
        {
            using (var connection = ConnectionMultiplexer.Connect(_configurationOptions))
            {

            }
        }

        public bool Any(string key, int db = 0)
        {
            using (var connection = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                IDatabase database = connection.GetDatabase(db);
                return database.KeyExists(key);
            }
        }

        public void Remove(string key, int db = 0)
        {
            using (var connection = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                IDatabase database = connection.GetDatabase(db);
                database.KeyDelete(key);
            }
        }

        public void Remove(RedisKey[] key, int db = 0)
        {
            using (var connection = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                IDatabase database = connection.GetDatabase(db);
                database.KeyDelete(key);
            }
        }
    }
}
