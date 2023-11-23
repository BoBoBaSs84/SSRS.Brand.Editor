using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Infrastructure.Installers;

namespace SSRS.Brand.Editor.InfrastructureTests;

[TestClass]
public abstract class InfrastructureTestBase
{
	private readonly IServiceProvider _serviceProvider;

	public InfrastructureTestBase()
		=> _serviceProvider = CreateServiceProvider();

	public T GetService<T>() where T : class =>
		_serviceProvider.GetRequiredService(typeof(T)) is not T service
		? throw new ArgumentException($"{typeof(T)} needs to be registered.")
		: service;

	private static ServiceProvider CreateServiceProvider()
	{
		ServiceCollection services = new();
		_ = services.AddInfrastructureServices();
		return services.BuildServiceProvider();
	}
}
