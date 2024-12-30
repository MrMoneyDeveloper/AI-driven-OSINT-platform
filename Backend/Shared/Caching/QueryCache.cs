using System;
using Microsoft.Extensions.Caching.Memory;

namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Handles caching of results from frequently executed database queries.
    /// </summary>
    public class QueryCache : IQueryCache
    {
        private readonly IMemoryCache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryCache"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache dependency provided by DI.</param>
        public QueryCache(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        /// <inheritdoc />
        public T GetQueryResult<T>(string key)
        {
            return _cache.TryGetValue(key, out T value) ? value : default;
        }

        /// <inheritdoc />
        public void SetQueryResult<T>(string key, T queryResult, int durationInSeconds)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Cache key cannot be null or empty.", nameof(key));
            }

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(durationInSeconds)
            };

            _cache.Set(key, queryResult, cacheOptions);
        }

        /// <inheritdoc />
        public void RemoveQueryResult(string key)
        {
            _cache.Remove(key);
        }
    }
}
