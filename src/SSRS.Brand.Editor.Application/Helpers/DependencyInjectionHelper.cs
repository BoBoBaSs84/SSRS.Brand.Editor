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
	/// Adds the application services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddScopedViewModels();
		services.AddSingletonViewModels();
		services.AddTransientViewModels();

		return services;
	}
}
