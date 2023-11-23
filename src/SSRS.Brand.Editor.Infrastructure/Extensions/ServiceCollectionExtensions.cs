using SSRS.Brand.Editor.Application.Interfaces.Infrastructure.Services;
using SSRS.Brand.Editor.Infrastructure.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace SSRS.Brand.Editor.Infrastructure.Extensions;

/// <summary>
/// The infrastructure service collection extensions.
/// </summary>
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Adds the logger service to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection AddLoggerService(this IServiceCollection services)
	{
		services.TryAddSingleton(typeof(ILoggerService<>), typeof(LoggerService<>));

		services.AddLogging(config =>
		{
			config.AddEventLog(settings => settings.SourceName = "SSRS.Brand.Editor");
			config.SetMinimumLevel(LogLevel.Error);
		});

		return services;
	}

	/// <summary>
	/// Adds the singleton services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection AddSingletonServices(this IServiceCollection services)
	{
		services.TryAddSingleton<IFileService, FileService>();

		return services;
	}
}
