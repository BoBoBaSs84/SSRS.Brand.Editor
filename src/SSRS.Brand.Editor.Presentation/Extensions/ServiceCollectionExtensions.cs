using SSRS.Brand.Editor.Presentation.Windows;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SSRS.Brand.Editor.Presentation.Extensions;

/// <summary>
/// The presentation service collection extensions.
/// </summary>
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Adds the wpf windows to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection AddWindows(this IServiceCollection services)
	{
		services.TryAddTransient<MainWindow>();

		return services;
	}
}
