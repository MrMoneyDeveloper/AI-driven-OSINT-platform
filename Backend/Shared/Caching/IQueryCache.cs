namespace AI_driven_OSINT_platform
{
    /// <summary>
    /// Interface for caching results of frequently executed database queries.
    /// </summary>
    public interface IQueryCache
    {
        /// <summary>
        /// Retrieves cached query results by key.
        /// </summary>
        /// <typeparam name="T">The type of the cached query results.</typeparam>
        /// <param name="key">The cache key (e.g., query identifier or parameters).</param>
        /// <returns>The cached query results or default value if not found.</returns>
        T GetQueryResult<T>(string key);

        /// <summary>
        /// Caches the results of a database query.
        /// </summary>
        /// <typeparam name="T">The type of the query results to cache.</typeparam>
        /// <param name="key">The cache key (e.g., query identifier or parameters).</param>
        /// <param name="queryResult">The query results to cache.</param>
        /// <param name="durationInSeconds">The duration in seconds to cache the query results.</param>
        void SetQueryResult<T>(string key, T queryResult, int durationInSeconds);

        /// <summary>
        /// Removes cached query results by key.
        /// </summary>
        /// <param name="key">The cache key (e.g., query identifier or parameters).</param>
        void RemoveQueryResult(string key);
    }
}
