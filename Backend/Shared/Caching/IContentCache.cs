namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Interface for caching static content such as images, stylesheets, and other resources.
    /// </summary>
    public interface IContentCache
    {
        /// <summary>
        /// Retrieves cached content by key.
        /// </summary>
        /// <typeparam name="T">The type of the cached content.</typeparam>
        /// <param name="key">The cache key (e.g., file path or content identifier).</param>
        /// <returns>The cached content or default value if not found.</returns>
        T GetContent<T>(string key);

        /// <summary>
        /// Caches static content.
        /// </summary>
        /// <typeparam name="T">The type of the content to cache.</typeparam>
        /// <param name="key">The cache key (e.g., file path or content identifier).</param>
        /// <param name="content">The content to cache.</param>
        /// <param name="durationInSeconds">The duration in seconds to cache the content.</param>
        void SetContent<T>(string key, T content, int durationInSeconds);

        /// <summary>
        /// Removes cached content by key.
        /// </summary>
        /// <param name="key">The cache key (e.g., file path or content identifier).</param>
        void RemoveContent(string key);
    }
}
