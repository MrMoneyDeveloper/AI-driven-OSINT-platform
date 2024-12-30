using Microsoft.Extensions.DependencyInjection;
using ProjectNamespace.Shared.Caching;
using ProjectNamespace.Shared.Helpers;
using ProjectNamespace.Shared.Logging;
using ProjectNamespace.Shared.Services;
using ProjectNamespace.Shared.Utilities;
using ProjectNamespace.Shared.Kernel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Web;

namespace AI_driven_OSINT_platform.Backend.Core.DependencyInjection
{
    /// <summary>
    /// Registers shared services, utilities, helpers, and other components in the dependency injection container.
    /// </summary>
    public static class SharedServiceRegistration
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            // Caching Services
            services.AddScoped<IMemoryCacheManager, MemoryCacheManager>();
            services.AddScoped<IRedisCacheManager, RedisCacheManager>();
            services.AddScoped<ISessionCacheManager, SessionCacheManager>();
            services.AddScoped<IQueryCache, QueryCache>();
            services.AddScoped<IApiResponseCache, ApiResponseCache>();
            services.AddScoped<IAuthenticationCache, AuthenticationCache>();
            services.AddScoped<IContentCache, ContentCache>();
            services.AddScoped<IConfigurationCache, ConfigurationCache>();
            services.AddScoped<INotificationCache, NotificationCache>();
            services.AddScoped<IBackgroundJobCache, BackgroundJobCache>();

            // Logging Services
            services.AddSingleton<ILoggingService, LoggingService>();
            services.AddSingleton<IErrorLogger, ErrorLogger>();
            services.AddSingleton<IPerformanceLogger, PerformanceLogger>();
            services.AddSingleton<ISecurityLogger, SecurityLogger>();
            services.AddSingleton<ITransactionLogger, TransactionLogger>();
            services.AddSingleton<IAuditLogger, AuditLogger>();
            services.AddSingleton<IEventLogger, EventLogger>();
            services.AddSingleton<ISystemLogger, SystemLogger>();
            services.AddSingleton<IApiLogger, ApiLogger>();
            services.AddSingleton<ICustomLogger, CustomLogger>();
            services.AddSingleton<IEmailLogger, EmailLogger>();

            // Shared Services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDataCollectionService, DataCollectionService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IGraphService, GraphService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ICachingService, CachingService>();

            // Helper Utilities
            services.AddScoped<IDateTimeHelper, DateTimeHelper>();
            services.AddScoped<IStringHelper, StringHelper>();
            services.AddScoped<IValidationHelper, ValidationHelper>();
            services.AddScoped<IFileHelper, FileHelper>();
            services.AddScoped<IEncryptionHelper, EncryptionHelper>();
            services.AddScoped<INetworkHelper, NetworkHelper>();
            services.AddScoped<IDataConversionHelper, DataConversionHelper>();
            services.AddScoped<IAPIResponseHelper, APIResponseHelper>();
            services.AddScoped<IPaginationHelper, PaginationHelper>();
            services.AddScoped<ILoggingHelper, LoggingHelper>();

            // General Utilities
            services.AddScoped<IJsonUtility, JsonUtility>();
            services.AddScoped<ICsvUtility, CsvUtility>();
            services.AddScoped<IXmlUtility, XmlUtility>();
            services.AddScoped<IEmailUtility, EmailUtility>();
            services.AddScoped<IHttpUtility, HttpUtility>();
            services.AddScoped<IErrorHandlingUtility, ErrorHandlingUtility>();
            services.AddScoped<IDataSanitizationUtility, DataSanitizationUtility>();
            services.AddScoped<IFileCompressionUtility, FileCompressionUtility>();
            services.AddScoped<IExcelUtility, ExcelUtility>();
            services.AddScoped<ILocalizationUtility, LocalizationUtility>();

            // Kernel
            services.AddScoped<IBaseEntity, BaseEntity>();
            services.AddScoped<IDomainEvent, DomainEvent>();
            services.AddScoped<IValueObject, ValueObject>();
            services.AddScoped<IAggregateRoot, AggregateRoot>();
            services.AddScoped<IRepositoryBase, RepositoryBase>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificationBase, NotificationBase>();
            services.AddScoped<ICommandBase, CommandBase>();
            services.AddScoped<IQueryBase, QueryBase>();
            services.AddScoped<IHandlerBase, HandlerBase>();

            return services;
        }
    }
}
