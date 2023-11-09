using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SSRS.Brand.Editor.Infrastructure.Installers;

namespace SSRS.Brand.Editor.InfrastructureTests;

public class InfrastructureTestBase
{
	private readonly IServiceProvider _serviceProvider;

	public InfrastructureTestBase()
	{
		IHost host = CreateHostBuilder().Build();
		_serviceProvider = host.Services;
	}

	public T GetService<T>() where T : class =>
		_serviceProvider.GetRequiredService(typeof(T)) is not T service
		? throw new ArgumentException($"{typeof(T)} needs to be registered.")
		: service;

	private static IHostBuilder CreateHostBuilder()
		=> Host.CreateDefaultBuilder()
		.ConfigureServices((context, services)
			=> services.AddInfrastructureServices());
}
