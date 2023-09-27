using System.Windows;
using System.Windows.Threading;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SSRS.Brand.Editor.Application.Interfaces.Infrastructure.Services;
using SSRS.Brand.Editor.Infrastructure.Installer;
using SSRS.Brand.Editor.Presentation.Installer;
using SSRS.Brand.Editor.Presentation.Windows;

using WinApplication = System.Windows.Application;

namespace SSRS.Brand.Editor;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : WinApplication
{
	private readonly IHost _host;
	private readonly ILoggerService<App> _loggerService;

	private static readonly Action<ILogger, string, Exception?> LogInformation =
		LoggerMessage.Define<string>(LogLevel.Information, 0, "{Information}");

	private static readonly Action<ILogger, Exception?> LogCritical =
		LoggerMessage.Define(LogLevel.Critical, 0, string.Empty);

	/// <summary>
	/// Initializes a new instance of the app class.
	/// </summary>
	public App()
	{
		_host = CreateHostBuilder().Build();
		_loggerService = GetService<ILoggerService<App>>();

		DispatcherUnhandledException += OnUnhandledException;
	}

	/// <summary>
	/// The <see cref="GetService{T}"/> method should the requested registered service.
	/// </summary>
	/// <typeparam name="T">The requested service.</typeparam>
	/// <returns>The registered service.</returns>
	/// <exception cref="ArgumentException">If a service is not registered.</exception>
	public static T GetService<T>() where T : class =>
		(Current as App)!._host.Services.GetRequiredService(typeof(T)) is not T service
		? throw new ArgumentException($"{typeof(T)} needs to be registered.")
		: service;

	private async void Application_Startup(object sender, StartupEventArgs e)
	{
		_loggerService.Log(LogInformation, "Apllication starting...");
		await _host.StartAsync().ConfigureAwait(false);
		MainWindow mainWindow = GetService<MainWindow>();
		mainWindow.Show();
	}

	private async void Application_Exit(object sender, ExitEventArgs e)
	{
		_loggerService.Log(LogInformation, "Apllication exiting...");
		using (_host)
			await _host.StopAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
	}

	private void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
		=> _loggerService.Log(LogCritical, args.Exception);

	private static IHostBuilder CreateHostBuilder()
		=> Host.CreateDefaultBuilder()
		.ConfigureServices((context, services) =>
		{
			_ = services.AddInfrastructureServices();
			_ = services.AddPresentationServices();
		});
}
