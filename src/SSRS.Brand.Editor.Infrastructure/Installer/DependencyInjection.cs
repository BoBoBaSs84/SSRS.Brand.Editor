using SSRS.Brand.Editor.Infrastructure.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace SSRS.Brand.Editor.Infrastructure.Installer;

/// <summary>
/// The infrastructure dependency injection class.
/// </summary>
public static class DependencyInjection
{
	/// <summary>
	/// Adds the infrastructure services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
	{
		services.AddLoggerService();

		return services;
	}
}
