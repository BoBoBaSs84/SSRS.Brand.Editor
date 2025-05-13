using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SSRS.Brand.Editor.Infrastructure.Extensions;

namespace SSRS.Brand.Editor.Infrastructure.Installer;
/// <summary>
/// The infrastructure dependency injection installer class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, dependency injection.")]
public static class DependencyInjectionInstaller
{
	/// <summary>
	/// Registers the infrastructure services to the <paramref name="services"/> collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <param name="environment">The host environment instance to use.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IHostEnvironment environment)
	{
		services.RegisterLoggerService(environment)
			.RegisterHttpClients()
			.RegisterProviders()
			.RegisterServices();

		return services;
	}
}
