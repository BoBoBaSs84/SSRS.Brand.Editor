using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Infrastructure.Helpers;

namespace SSRS.Brand.Editor.InfrastructureTests;

[TestClass]
public abstract class InfrastructureTestBase
{
	private static TestContext? s_context;
	private static IServiceProvider? s_serviceProvider;

	[AssemblyInitialize]
	public static void AssemblyInitialize(TestContext context)
	{
		s_context = context;
		s_serviceProvider = GetServiceProvider();
	}

	[TestInitialize]
	public void TestInitialize()
		=> s_context?.WriteLine($"Initialize {s_context.TestName} ..");

	[TestCleanup]
	public void TestCleanup()
		=> s_context?.WriteLine($"Cleanup {s_context.TestName} ..");

	/// <summary>
	/// Returns the requested registered service.
	/// </summary>
	/// <typeparam name="T">The requested service.</typeparam>
	/// <returns>The registered service.</returns>
	/// <exception cref="ArgumentException">If the service is not registered.</exception>
	public static T GetService<T>() where T : class
	{
		s_serviceProvider ??= GetServiceProvider();
		return s_serviceProvider.GetRequiredService(typeof(T)) is not T service
			? throw new ArgumentException($"{typeof(T)} needs to be registered.")
			: service;
	}

	private static ServiceProvider GetServiceProvider()
	{
		IServiceCollection services = new ServiceCollection();
		_ = services.AddInfrastructureServices();
		return services.BuildServiceProvider();
	}
}
