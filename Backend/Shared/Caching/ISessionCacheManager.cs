namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Interface for managing session-specific caching.
    /// </summary>
    public interface ISessionCacheManager
    {
        /// <summary>
        /// Retrieves a cached session value by key.
        /// </summary>
        /// <typeparam name="T">The type of the cached value.</typeparam>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="key">The cache key.</param>
        /// <returns>The cached value or default(T) if not found.</returns>
        T Get<T>(string sessionId, string key);

        /// <summary>
        /// Caches a session value with a specified key and expiration time.
        /// </summary>
        /// <typeparam name="T">The type of the value to cache.</typeparam>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="key">The cache key.</param>
        /// <param name="value">The value to cache.</param>
        /// <param name="durationInSeconds">The duration in seconds to cache the value.</param>
        void Set<T>(string sessionId, string key, T value, int durationInSeconds);

        /// <summary>
        /// Removes a cached session value by key.
        /// </summary>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="key">The cache key.</param>
        void Remove(string sessionId, string key);
    }
}
