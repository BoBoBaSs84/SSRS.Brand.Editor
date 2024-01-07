using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Application.Extensions;

namespace SSRS.Brand.Editor.Application.Helpers;

/// <summary>
/// The application dependency injection helper class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Dependency injection helper.")]
public static class DependencyInjectionHelper
{
	private static IServiceProvider? s_serviceProvider;

	/// <summary>
	/// Adds the application services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddScopedViewModels();
		services.AddSingletonViewModels();
		services.AddTransientViewModels();

		return services;
	}

	/// <summary>
	/// Returns the requested registered service.
	/// </summary>
	/// <typeparam name="T">The requested service.</typeparam>
	/// <returns>The registered service.</returns>
	/// <exception cref="ArgumentException">If the service is not registered.</exception>
	public static T GetService<T>() where T : class
	{
		s_serviceProvider ??= GetServiceProvider();
		return s_serviceProvider.GetRequiredService(typeof(T)) is not T service
			? throw new ArgumentException($"{typeof(T)} needs to be registered.")
			: service;
	}

	private static ServiceProvider GetServiceProvider()
	{
		IServiceCollection services = new ServiceCollection();
		services.AddApplicationServices();
		return services.BuildServiceProvider();
	}
}
