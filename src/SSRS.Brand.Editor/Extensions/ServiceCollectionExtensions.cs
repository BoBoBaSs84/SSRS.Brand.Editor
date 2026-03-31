// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Diagnostics.CodeAnalysis;

using SSRS.Brand.Editor.Application.Installers;
using SSRS.Brand.Editor.Domain.Installers;
using SSRS.Brand.Editor.Infrastructure.Installers;
using SSRS.Brand.Editor.Presentation.Installers;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SSRS.Brand.Editor.Extensions;

/// <summary>
/// The service collection extensions class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here.")]
internal static class ServiceCollectionExtensions
{
	/// <summary>
	/// Registers the required services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <param name="environment">The host environment instance to use.</param>
	/// <returns>The enriched service collection.</returns>
	internal static IServiceCollection RegisterServices(this IServiceCollection services, IHostEnvironment environment)
	{
		services.RegisterApplicationServices();
		services.RegisterDomainServices();
		services.RegisterInfrastructureServices(environment);
		services.RegisterPresentationServices();

		return services;
	}
}
