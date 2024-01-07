using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using SSRS.Brand.Editor.Presentation.Views;

namespace SSRS.Brand.Editor.Presentation.Extensions;

/// <summary>
/// The presentation service collection extensions.
/// </summary>
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Adds the scoped views to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection AddScopedViews(this IServiceCollection services)
	{

		return services;
	}

	/// <summary>
	/// Adds the singleton views to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection AddSingletonViews(this IServiceCollection services)
	{
		services.TryAddSingleton<MainView>();

		return services;
	}

	/// <summary>
	/// Adds the transient views to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection AddTransientViews(this IServiceCollection services)
	{

		return services;
	}
}
