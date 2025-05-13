using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Extensions;
/// <summary>
/// The domain service collection extensions class.
/// </summary>
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers the required domain models to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The same service collection instance, so that multiple calls can be chained.</returns>
	internal static IServiceCollection RegisterModels(this IServiceCollection services)
	{
		services.TryAddSingleton<AboutModel>();

		return services;
	}
}
