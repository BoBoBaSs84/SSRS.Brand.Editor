using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Extensions;

/// <summary>
/// The domain service collection extensions.
/// </summary>
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers models to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterModels(this IServiceCollection services)
	{
		services.TryAddSingleton<BrandingModel>();
		services.TryAddSingleton<ColorsModel>();
		services.TryAddSingleton<InterfaceModel>();
		services.TryAddSingleton<ThemeModel>();
		services.TryAddSingleton<MetadataModel>();
		services.TryAddSingleton<ItemModel>();

		return services;
	}
}
