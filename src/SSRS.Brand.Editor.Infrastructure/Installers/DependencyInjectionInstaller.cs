using System.Diagnostics.CodeAnalysis;

using SSRS.Brand.Editor.Infrastructure.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SSRS.Brand.Editor.Infrastructure.Installers;

/// <summary>
/// The infrastructure dependency injection class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, dependency injection.")]
public static class DependencyInjectionInstaller
{
	/// <summary>
	/// Registers the infrastructure services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <param name="environment">The host environment instance to use.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IHostEnvironment environment)
	{
		services.RegisterLoggerService(environment)
			.RegisterHttpClients()
			.RegisterServices();

		return services;
	}
}
