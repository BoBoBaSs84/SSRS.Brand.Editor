// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Diagnostics.CodeAnalysis;

using SSRS.Brand.Editor.Presentation.Extensions;

using Microsoft.Extensions.DependencyInjection;

namespace SSRS.Brand.Editor.Presentation.Installers;

/// <summary>
/// The presentation dependency injection class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here.")]
public static class DependencyInjectionInstaller
{
	/// <summary>
	/// Registers the presentation services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
	public static IServiceCollection RegisterPresentationServices(this IServiceCollection services)
	{
		services.RegisterControls()
			.RegisterServices()
			.RegisterWindows();

		return services;
	}
}
