using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Application.Extensions;

namespace SSRS.Brand.Editor.Application.Helpers;

/// <summary>
/// The application dependency injection helper class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Dependency injection helper.")]
public static class DependencyInjectionHelper
{
	/// <summary>
	/// Registers the application services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
	{
		services.RegisterViewModels();
		services.RegisterServices();

		return services;
	}
}
