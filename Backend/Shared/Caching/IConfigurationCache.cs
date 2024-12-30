namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Interface for caching configuration settings.
    /// </summary>
    public interface IConfigurationCache
    {
        /// <summary>
        /// Retrieves a cached configuration value by key.
        /// </summary>
        /// <typeparam name="T">The type of the configuration value.</typeparam>
        /// <param name="key">The cache key (e.g., configuration name).</param>
        /// <returns>The cached configuration value or default value if not found.</returns>
        T GetConfiguration<T>(string key);

        /// <summary>
        /// Caches a configuration value.
        /// </summary>
        /// <typeparam name="T">The type of the configuration value to cache.</typeparam>
        /// <param name="key">The cache key (e.g., configuration name).</param>
        /// <param name="value">The value to cache.</param>
        /// <param name="durationInSeconds">The duration in seconds to cache the configuration.</param>
        void SetConfiguration<T>(string key, T value, int durationInSeconds);

        /// <summary>
        /// Removes a cached configuration value by key.
        /// </summary>
        /// <param name="key">The cache key (e.g., configuration name).</param>
        void RemoveConfiguration(string key);
    }
}
