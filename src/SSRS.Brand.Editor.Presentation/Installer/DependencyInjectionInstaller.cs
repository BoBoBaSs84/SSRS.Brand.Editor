using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Presentation.Extensions;

namespace SSRS.Brand.Editor.Presentation.Installer;
/// <summary>
/// The presentation dependency injection installer class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, dependency injection.")]
public static class DependencyInjectionInstaller
{
	/// <summary>
	/// Registers the presentation services to the <paramref name="services"/> collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection RegisterPresentationServices(this IServiceCollection services)
	{
		services.RegisterForms()
			.RegisterFactories()
			.RegisterServices();

		return services;
	}
}
