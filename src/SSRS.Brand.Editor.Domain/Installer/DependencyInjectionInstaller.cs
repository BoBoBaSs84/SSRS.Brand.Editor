using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Domain.Extensions;

namespace SSRS.Brand.Editor.Domain.Installer;
/// <summary>
/// The domain dependency injection installer class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here.")]
public static class DependencyInjectionInstaller
{
	/// <summary>
	/// Registers the domain services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The same service collection instance, so that multiple calls can be chained.</returns>
	public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
	{
		services.RegisterModels();

		return services;
	}
}
