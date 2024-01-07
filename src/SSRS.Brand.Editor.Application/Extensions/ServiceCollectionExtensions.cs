using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.Application.Extensions;

/// <summary>
/// The application service collection extensions.
/// </summary>
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Adds the scoped view models to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection AddScopedViewModels(this IServiceCollection services)
	{

		return services;
	}

	/// <summary>
	/// Adds the singleton view models to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection AddSingletonViewModels(this IServiceCollection services)
	{
		services.TryAddSingleton<MainViewModel>();

		return services;
	}

	/// <summary>
	/// Adds the transient view models to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection AddTransientViewModels(this IServiceCollection services)
	{

		return services;
	}
}
