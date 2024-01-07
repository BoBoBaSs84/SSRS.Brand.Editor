using System.Windows;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SSRS.Brand.Editor.Application.Interfaces.Infrastructure.Services;
using SSRS.Brand.Editor.Infrastructure.Helpers;
using SSRS.Brand.Editor.Presentation.Helpers;
using SSRS.Brand.Editor.Presentation.Views;

using IDIH = SSRS.Brand.Editor.Infrastructure.Helpers.DependencyInjectionHelper;
using PDIH = SSRS.Brand.Editor.Presentation.Helpers.DependencyInjectionHelper;

namespace SSRS.Brand.Editor;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
	private readonly IHost _host;
	private readonly ILoggerService<App> _loggerService;

	private static readonly Action<ILogger, string, Exception?> LogInformation =
		LoggerMessage.Define<string>(LogLevel.Information, 0, "{Information}");

	private static readonly Action<ILogger, Exception?> LogCritical =
		LoggerMessage.Define(LogLevel.Critical, 0, string.Empty);

	/// <summary>
	/// Initializes a new instance of the <see cref="App"/> class.
	/// </summary>
	public App()
	{
		_host = CreateHostBuilder().Build();
		_loggerService = IDIH.GetService<ILoggerService<App>>();

		DispatcherUnhandledException += (s, e) => OnUnhandledException(e.Exception);
	}

	private async void Application_Startup(object sender, StartupEventArgs e)
	{
		_loggerService.Log(LogInformation, "Application starting...");
		await _host.StartAsync().ConfigureAwait(false);

		MainView mainWindow = PDIH.GetService<MainView>();
		mainWindow.Show();
	}

	private async void Application_Exit(object sender, ExitEventArgs e)
	{
		_loggerService.Log(LogInformation, "Application exiting...");

		using (_host)
			await _host.StopAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
	}

	private void OnUnhandledException(Exception exception)
		=> _loggerService.Log(LogCritical, exception);

	private static IHostBuilder CreateHostBuilder()
		=> Host.CreateDefaultBuilder()
		.ConfigureServices((context, services) =>
		{
			_ = services.AddInfrastructureServices();
			_ = services.AddPresentationServices();
		});
}
