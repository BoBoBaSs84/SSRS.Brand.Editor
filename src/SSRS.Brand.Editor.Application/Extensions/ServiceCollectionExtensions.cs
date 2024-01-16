using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using SSRS.Brand.Editor.Application.Interfaces.Application.Services;
using SSRS.Brand.Editor.Application.Services;
using SSRS.Brand.Editor.Application.ViewModels;
using SSRS.Brand.Editor.Application.ViewModels.Base;

namespace SSRS.Brand.Editor.Application.Extensions;

/// <summary>
/// The application service collection extensions.
/// </summary>
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers view models to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterViewModels(this IServiceCollection services)
	{
		services.TryAddSingleton<MainViewModel>();
		services.TryAddSingleton<ColorsViewModel>();
		services.TryAddSingleton<MetaDataViewModel>();

		return services;
	}

	/// <summary>
	/// Registers the application services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterServices(this IServiceCollection services)
	{
		services.TryAddSingleton<INavigationService, NavigationService>();
		
		services.TryAddSingleton<Func<Type, ViewModelBase>>(provider
			=> type => (ViewModelBase)provider.GetRequiredService(type));

		return services;
	}
}
