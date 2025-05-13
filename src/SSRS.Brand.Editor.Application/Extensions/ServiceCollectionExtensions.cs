using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using SSRS.Brand.Editor.Application.Abstractions.Application.Providers;
using SSRS.Brand.Editor.Application.Providers;
using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.Application.Extensions;
/// <summary>
/// The application service collection extensions class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, dependency injection.")]
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers the required application providers to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterProviders(this IServiceCollection services)
	{
		services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

		return services;
	}

	/// <summary>
	/// Registers the required application services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterServices(this IServiceCollection services)
	{

		return services;
	}

	/// <summary>
	/// Registers the required view models to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterViewModels(this IServiceCollection services)
	{
		services.TryAddSingleton<AboutViewModel>();
		services.TryAddSingleton<MainViewModel>();

		return services;
	}
}
