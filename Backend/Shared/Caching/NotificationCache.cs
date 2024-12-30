using System;
using Microsoft.Extensions.Caching.Memory;

namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Handles caching of notifications for quick access.
    /// </summary>
    public class NotificationCache : INotificationCache
    {
        private readonly IMemoryCache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationCache"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache dependency provided by DI.</param>
        public NotificationCache(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        /// <inheritdoc />
        public T GetNotifications<T>(string key)
        {
            return _cache.TryGetValue(key, out T value) ? value : default;
        }

        /// <inheritdoc />
        public void SetNotifications<T>(string key, T notifications, int durationInSeconds)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Cache key cannot be null or empty.", nameof(key));
            }

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(durationInSeconds)
            };

            _cache.Set(key, notifications, cacheOptions);
        }

        /// <inheritdoc />
        public void RemoveNotifications(string key)
        {
            _cache.Remove(key);
        }
    }
}
