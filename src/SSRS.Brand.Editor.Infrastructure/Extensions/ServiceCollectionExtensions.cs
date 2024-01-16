using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

using SSRS.Brand.Editor.Application.Interfaces.Infrastructure.Services;
using SSRS.Brand.Editor.Infrastructure.Services;

namespace SSRS.Brand.Editor.Infrastructure.Extensions;

/// <summary>
/// The infrastructure service collection extensions.
/// </summary>
internal static class ServiceCollectionExtensions
{
	private const string EventSourceName = "SSRS.Brand.Editor";

	/// <summary>
	/// Registers the logger service to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here.")]
	internal static IServiceCollection RegisterLoggerService(this IServiceCollection services)
	{
		services.TryAddSingleton(typeof(ILoggerService<>), typeof(LoggerService<>));

		services.AddLogging(config =>
		{
			config.AddEventLog(settings => settings.SourceName = EventSourceName);
			config.SetMinimumLevel(LogLevel.Warning);
		});

		return services;
	}

	/// <summary>
	/// Registers the singleton services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterSingletonServices(this IServiceCollection services)
	{
		services.TryAddSingleton<IFileService, FileService>();

		return services;
	}
}
