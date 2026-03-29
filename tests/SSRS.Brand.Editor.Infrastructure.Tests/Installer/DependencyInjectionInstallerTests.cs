using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Moq;

using SSRS.Brand.Editor.Infrastructure.Installers;

namespace SSRS.Brand.Editor.Infrastructure.Tests.Installer;

[TestClass]
public sealed class DependencyInjectionInstallerTests : InfrastructureTestBase
{
	private readonly Mock<IHostEnvironment> _hostEnvironmentMock;

	public DependencyInjectionInstallerTests()
	{
		_hostEnvironmentMock = new();
	}


	[TestMethod]
	[TestCategory("DependencyInjection")]
	public void RegisterInfrastructureServicesForDevelopmentTest()
	{
		_hostEnvironmentMock.Setup(x => x.EnvironmentName).Returns("Development");
		ServiceCollection services = new();

		services.RegisterInfrastructureServices(_hostEnvironmentMock.Object);

		Assert.AreEqual(45, services.Count);
	}

	[TestMethod]
	[TestCategory("DependencyInjection")]
	public void RegisterInfrastructureServicesForProductionTest()
	{
		_hostEnvironmentMock.Setup(x => x.EnvironmentName).Returns("Production");
		ServiceCollection services = new();

		services.RegisterInfrastructureServices(_hostEnvironmentMock.Object);

		Assert.AreEqual(33, services.Count);
	}
}
