using System.Diagnostics.CodeAnalysis;

using SSRS.Brand.Editor.Domain.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace SSRS.Brand.Editor.Domain.Installers;

/// <summary>
/// The domain dependency injection class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here.")]
public static class DependencyInjectionInstaller
{
	/// <summary>
	/// Registers the domain services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
	{
		services.RegisterModels();

		return services;
	}
}
