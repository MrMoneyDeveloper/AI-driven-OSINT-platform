using System;
using Microsoft.Extensions.Caching.Memory;

namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Handles caching of user authentication tokens for faster validation.
    /// </summary>
    public class AuthenticationCache : IAuthenticationCache
    {
        private readonly IMemoryCache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationCache"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache dependency provided by DI.</param>
        public AuthenticationCache(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        /// <inheritdoc />
        public T GetToken<T>(string key)
        {
            return _cache.TryGetValue(key, out T value) ? value : default;
        }

        /// <inheritdoc />
        public void SetToken<T>(string key, T token, int durationInSeconds)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Cache key cannot be null or empty.", nameof(key));
            }

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(durationInSeconds)
            };

            _cache.Set(key, token, cacheOptions);
        }

        /// <inheritdoc />
        public void RemoveToken(string key)
        {
            _cache.Remove(key);
        }
    }
}
