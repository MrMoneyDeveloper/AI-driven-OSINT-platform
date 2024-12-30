using System;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Handles distributed caching using Redis.
    /// </summary>
    public class RedisCacheManager : IRedisCacheManager
    {
        private readonly StackExchange.Redis.IDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisCacheManager"/> class.
        /// </summary>
        /// <param name="connectionMultiplexer">The Redis connection multiplexer.</param>
        public RedisCacheManager(IConnectionMultiplexer connectionMultiplexer)
        {
            _database = connectionMultiplexer.GetDatabase();
        }

        /// <inheritdoc />
        public T Get<T>(string key)
        {
            var cachedValue = _database.StringGet(key);
            if (!cachedValue.HasValue)
                return default;

            return JsonConvert.DeserializeObject<T>(cachedValue);
        }

        /// <inheritdoc />
        public void Set<T>(string key, T value, int durationInSeconds)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Cache key cannot be null or empty.", nameof(key));
            }

            var serializedValue = JsonConvert.SerializeObject(value);
            _database.StringSet(key, serializedValue, TimeSpan.FromSeconds(durationInSeconds));
        }

        /// <inheritdoc />
        public void Remove(string key)
        {
            _database.KeyDelete(key);
        }
    }
}
