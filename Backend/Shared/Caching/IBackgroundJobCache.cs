namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Interface for caching data related to background jobs.
    /// </summary>
    public interface IBackgroundJobCache
    {
        /// <summary>
        /// Retrieves cached data for a background job by key.
        /// </summary>
        /// <typeparam name="T">The type of the cached data.</typeparam>
        /// <param name="key">The cache key (e.g., job identifier).</param>
        /// <returns>The cached data or default value if not found.</returns>
        T GetJobData<T>(string key);

        /// <summary>
        /// Caches data for a background job.
        /// </summary>
        /// <typeparam name="T">The type of the data to cache.</typeparam>
        /// <param name="key">The cache key (e.g., job identifier).</param>
        /// <param name="data">The data to cache.</param>
        /// <param name="durationInSeconds">The duration in seconds to cache the data.</param>
        void SetJobData<T>(string key, T data, int durationInSeconds);

        /// <summary>
        /// Removes cached data for a background job by key.
        /// </summary>
        /// <param name="key">The cache key (e.g., job identifier).</param>
        void RemoveJobData(string key);
    }
}
