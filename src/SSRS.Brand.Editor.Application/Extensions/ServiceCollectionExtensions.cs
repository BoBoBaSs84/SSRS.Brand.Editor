using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Application.Abstractions.Application.Services;
using SSRS.Brand.Editor.Application.Services;
using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.Application.Extensions;
/// <summary>
/// The application service collection extensions class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, dependency injection.")]
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers the required application services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterServices(this IServiceCollection services)
	{
		services.AddSingleton<IEventService, EventService>();

		return services;
	}

	/// <summary>
	/// Registers the required view models to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterViewModels(this IServiceCollection services)
	{
		services.AddSingleton<AboutViewModel>();
		services.AddSingleton<MainViewModel>();

		return services;
	}
}
