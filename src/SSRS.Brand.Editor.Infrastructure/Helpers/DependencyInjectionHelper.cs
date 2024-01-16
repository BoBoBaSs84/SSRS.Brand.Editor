using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Infrastructure.Extensions;

namespace SSRS.Brand.Editor.Infrastructure.Helpers;

/// <summary>
/// The infrastructure dependency injection helper class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Dependency injection helper.")]
public static class DependencyInjectionHelper
{
	/// <summary>
	/// Adds the infrastructure services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
	{
		services.AddLoggerService();
		services.AddSingletonServices();

		return services;
	}
}
