using SSRS.Brand.Editor.Presentation.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace SSRS.Brand.Editor.Presentation.Installers;

/// <summary>
/// The presentation dependency injection installer class.
/// </summary>
public static class DependencyInjectionInstaller
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
