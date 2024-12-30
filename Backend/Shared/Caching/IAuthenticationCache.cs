namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Interface for caching user authentication tokens.
    /// </summary>
    public interface IAuthenticationCache
    {
        /// <summary>
        /// Retrieves an authentication token from the cache.
        /// </summary>
        /// <typeparam name="T">The type of the cached token.</typeparam>
        /// <param name="key">The cache key (e.g., user identifier).</param>
        /// <returns>The cached token or null if not found.</returns>
        T GetToken<T>(string key);

        /// <summary>
        /// Caches an authentication token.
        /// </summary>
        /// <typeparam name="T">The type of the token to cache.</typeparam>
        /// <param name="key">The cache key (e.g., user identifier).</param>
        /// <param name="token">The token to cache.</param>
        /// <param name="durationInSeconds">The duration in seconds to cache the token.</param>
        void SetToken<T>(string key, T token, int durationInSeconds);

        /// <summary>
        /// Removes an authentication token from the cache.
        /// </summary>
        /// <param name="key">The cache key (e.g., user identifier).</param>
        void RemoveToken(string key);
    }
}
