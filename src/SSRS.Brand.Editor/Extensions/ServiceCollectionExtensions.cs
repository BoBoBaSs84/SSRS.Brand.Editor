using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SSRS.Brand.Editor.Application.Installer;
using SSRS.Brand.Editor.Domain.Installer;
using SSRS.Brand.Editor.Infrastructure.Installer;
using SSRS.Brand.Editor.Presentation.Installer;

namespace SSRS.Brand.Editor.Extensions;
/// <summary>
/// The <see cref="IServiceCollection"/> extensions class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, dependency injection.")]
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers the all the required services to the <paramref name="services"/> collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <param name="environment">The host environment instance to use.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterServices(this IServiceCollection services, IHostEnvironment environment)
	{
		services.RegisterApplicationServices()
			.RegisterDomainServices()
			.RegisterInfrastructureServices(environment)
			.RegisterPresentationServices();

		return services;
	}
}
