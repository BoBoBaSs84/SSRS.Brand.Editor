using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SSRS.Brand.Editor.Application.Abstractions.Infrastructure.Services;
using SSRS.Brand.Editor.Extensions;
using SSRS.Brand.Editor.Presentation.Forms;

using FormsApplication = System.Windows.Forms.Application;

namespace SSRS.Brand.Editor;
internal sealed class Program
{
	private static IHost s_host = default!;
	private static ILoggerService<Program> s_logger = default!;

	private static readonly Action<ILogger, string, Exception?> LogInformation =
		LoggerMessage.Define<string>(LogLevel.Information, 0, "{Information}");

	private static readonly Action<ILogger, Exception?> LogCritical =
		LoggerMessage.Define(LogLevel.Critical, 0, string.Empty);

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	internal static void Main()
	{
		ApplicationConfiguration.Initialize();

		s_host = CreateDefaultBuilder().Build();
		s_logger = s_host.Services.GetRequiredService<ILoggerService<Program>>();

		AppDomain.CurrentDomain.UnhandledException += (s, e) => OnUnhandledException(e.ExceptionObject as Exception);

		s_logger.Log(LogInformation, "Application starting..");
		s_host.Start();

		MainForm mainForm = s_host.Services.GetRequiredService<MainForm>();
		FormsApplication.Run(mainForm);

		s_logger.Log(LogInformation, "Application exiting..");
	}

	private static void OnUnhandledException(Exception? exception)
		=> s_logger.Log(LogCritical, exception);

	private static IHostBuilder CreateDefaultBuilder()
	{
		IHostBuilder hostBuilder = Host.CreateDefaultBuilder()
			.RegisterAppSettingsConfiguration()
			.ConfigureServices((context, services) => services.RegisterServices(context.HostingEnvironment));

		return hostBuilder;
	}
}
