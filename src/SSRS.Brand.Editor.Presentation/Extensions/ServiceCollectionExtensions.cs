using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Application.Abstractions.Presentation.Services;
using SSRS.Brand.Editor.Presentation.Controls;
using SSRS.Brand.Editor.Presentation.Services;
using SSRS.Brand.Editor.Presentation.Windows;

namespace SSRS.Brand.Editor.Presentation.Extensions;

/// <summary>
/// The presentation service collection extensions.
/// </summary>
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers the required controls to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterControls(this IServiceCollection services)
	{
		services.AddSingleton<AboutControl>();

		return services;
	}

	/// <summary>
	/// Registers the required windows to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterWindows(this IServiceCollection services)
	{
		services.AddSingleton<MainWindow>();

		return services;
	}

	/// <summary>
	/// Registers the required presentation services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterServices(this IServiceCollection services)
	{
		services.AddSingleton<IFileDialogService, FileDialogService>();
		services.AddSingleton<INotificationService, NotificationService>();
		services.AddSingleton<IUserService, UserService>();

		return services;
	}
}
