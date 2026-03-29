using System.Diagnostics.CodeAnalysis;

using SSRS.Brand.Editor.Application.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace SSRS.Brand.Editor.Application.Installers;

/// <summary>
/// The application dependency injection class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here.")]
public static class DependencyInjectionInstaller
{
	/// <summary>
	/// Registers the application services to the <paramref name="services"/> collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
	{
		services.RegisterApplicationOptions()
			.RegisterNavigationService()
			.RegisterViewModels();

		return services;
	}
}
