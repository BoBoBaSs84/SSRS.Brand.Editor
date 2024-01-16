using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Presentation.Extensions;

namespace SSRS.Brand.Editor.Presentation.Helpers;

/// <summary>
/// The presentation dependency injection helper class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Dependency injection helper.")]
public static class DependencyInjectionHelper
{
	/// <summary>
	/// Adds the presentation services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection AddPresentationServices(this IServiceCollection services)
	{
		services.AddScopedViews();
		services.AddSingletonViews();
		services.AddTransientViews();

		return services;
	}
}
