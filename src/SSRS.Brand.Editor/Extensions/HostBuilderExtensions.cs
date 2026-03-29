using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SSRS.Brand.Editor.Extensions;

/// <summary>
/// The <see cref="IHostBuilder"/> extensions class.
/// </summary>
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here.")]
internal static class HostBuilderExtensions
{
	private const string FileName = "appsettings";
	private const string FileExtension = "json";

	/// <summary>
	/// Registers the application settings configuration to the host builder.
	/// </summary>
	/// <param name="hostBuilder">The host builder instance to use.</param>
	/// <returns>The enriched host builder.</returns>
	public static IHostBuilder RegisterAppSettingsConfiguration(this IHostBuilder hostBuilder)
	{
		hostBuilder.ConfigureAppConfiguration((context, builder) =>
		{
			builder.SetBasePath(context.HostingEnvironment.ContentRootPath);
			builder.AddJsonFile($"{FileName}.{FileExtension}", true, true);
			builder.AddJsonFile($"{FileName}.{context.HostingEnvironment.EnvironmentName}.{FileExtension}", true, false);
			builder.AddEnvironmentVariables();
		});

		return hostBuilder;
	}
}
