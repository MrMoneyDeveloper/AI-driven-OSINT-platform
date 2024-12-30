namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Interface for caching notifications for quick access.
    /// </summary>
    public interface INotificationCache
    {
        /// <summary>
        /// Retrieves cached notifications by key.
        /// </summary>
        /// <typeparam name="T">The type of the cached notifications.</typeparam>
        /// <param name="key">The cache key (e.g., user identifier).</param>
        /// <returns>The cached notifications or default value if not found.</returns>
        T GetNotifications<T>(string key);

        /// <summary>
        /// Caches notifications for a specific key.
        /// </summary>
        /// <typeparam name="T">The type of the notifications to cache.</typeparam>
        /// <param name="key">The cache key (e.g., user identifier).</param>
        /// <param name="notifications">The notifications to cache.</param>
        /// <param name="durationInSeconds">The duration in seconds to cache the notifications.</param>
        void SetNotifications<T>(string key, T notifications, int durationInSeconds);

        /// <summary>
        /// Removes cached notifications by key.
        /// </summary>
        /// <param name="key">The cache key (e.g., user identifier).</param>
        void RemoveNotifications(string key);
    }
}
