using SSRS.Brand.Editor.Presentation.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace SSRS.Brand.Editor.Presentation.Installer;

/// <summary>
/// The presentation dependency injection class.
/// </summary>
public static class DependencyInjection
{
	/// <summary>
	/// Adds the presentation services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection AddPresentationServices(this IServiceCollection services)
	{
		_ = services.AddWindows();

		return services;
	}
}
