namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Interface for managing in-memory caching of temporary data.
    /// </summary>
    public interface IMemoryCacheManager
    {
        /// <summary>
        /// Retrieves a cached value by key.
        /// </summary>
        /// <typeparam name="T">The type of the cached value.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <returns>The cached value or default(T) if not found.</returns>
        T Get<T>(string key);

        /// <summary>
        /// Caches a value with a specified key and duration.
        /// </summary>
        /// <typeparam name="T">The type of the value to cache.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <param name="value">The value to cache.</param>
        /// <param name="durationInSeconds">The duration in seconds to cache the value.</param>
        void Set<T>(string key, T value, int durationInSeconds);

        /// <summary>
        /// Removes a cached value by key.
        /// </summary>
        /// <param name="key">The cache key.</param>
        void Remove(string key);
    }
}
