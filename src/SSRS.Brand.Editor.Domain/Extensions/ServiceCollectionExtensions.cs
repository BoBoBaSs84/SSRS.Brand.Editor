using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Extensions;

/// <summary>
/// The service collection extensions class.
/// </summary>
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers the required models to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterModels(this IServiceCollection services)
	{
		services.AddSingleton<AboutModel>();
		services.AddTransient<BrandPackageModel>();

		return services;
	}
}
