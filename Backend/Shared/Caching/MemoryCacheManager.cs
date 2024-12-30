using System;
using Microsoft.Extensions.Caching.Memory;

namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Handles in-memory caching for temporary data storage.
    /// </summary>
    public class MemoryCacheManager : IMemoryCacheManager
    {
        private readonly IMemoryCache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryCacheManager"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache dependency provided by DI.</param>
        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        /// <inheritdoc />
        public T Get<T>(string key)
        {
            return _cache.TryGetValue(key, out T value) ? value : default;
        }

        /// <inheritdoc />
        public void Set<T>(string key, T value, int durationInSeconds)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Cache key cannot be null or empty.", nameof(key));
            }

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(durationInSeconds)
            };

            _cache.Set(key, value, cacheOptions);
        }

        /// <inheritdoc />
        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
