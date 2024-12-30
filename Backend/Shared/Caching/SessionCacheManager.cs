using System;
using Microsoft.Extensions.Caching.Memory;

namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Handles session-specific caching.
    /// </summary>
    public class SessionCacheManager : ISessionCacheManager
    {
        private readonly IMemoryCache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionCacheManager"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache dependency provided by DI.</param>
        public SessionCacheManager(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        /// <inheritdoc />
        public T Get<T>(string sessionId, string key)
        {
            var namespacedKey = GetNamespacedKey(sessionId, key);
            return _cache.TryGetValue(namespacedKey, out T value) ? value : default;
        }

        /// <inheritdoc />
        public void Set<T>(string sessionId, string key, T value, int durationInSeconds)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException("Session ID cannot be null or empty.", nameof(sessionId));
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Cache key cannot be null or empty.", nameof(key));
            }

            var namespacedKey = GetNamespacedKey(sessionId, key);

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(durationInSeconds)
            };

            _cache.Set(namespacedKey, value, cacheOptions);
        }

        /// <inheritdoc />
        public void Remove(string sessionId, string key)
        {
            var namespacedKey = GetNamespacedKey(sessionId, key);
            _cache.Remove(namespacedKey);
        }

        /// <summary>
        /// Generates a namespaced key for session-specific isolation.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="key">The cache key.</param>
        /// <returns>A unique namespaced key.</returns>
        private string GetNamespacedKey(string sessionId, string key)
        {
            return $"{sessionId}:{key}";
        }
    }
}
