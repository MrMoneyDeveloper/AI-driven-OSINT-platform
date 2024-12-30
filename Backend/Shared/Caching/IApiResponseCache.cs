namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Interface for ApiResponseCache to allow abstraction and testability.
    /// </summary>
    public interface IApiResponseCache
    {
        /// <summary>
        /// Retrieves a cached API response by key.
        /// </summary>
        /// <typeparam name="T">The type of the cached data.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <returns>The cached response or default value if not found.</returns>
        T Get<T>(string key);

        /// <summary>
        /// Caches an API response.
        /// </summary>
        /// <typeparam name="T">The type of the data to cache.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <param name="value">The value to cache.</param>
        /// <param name="durationInSeconds">The duration in seconds to cache the response.</param>
        void Set<T>(string key, T value, int durationInSeconds);

        /// <summary>
        /// Removes a cached API response by key.
        /// </summary>
        /// <param name="key">The cache key.</param>
        void Remove(string key);
    }
}
