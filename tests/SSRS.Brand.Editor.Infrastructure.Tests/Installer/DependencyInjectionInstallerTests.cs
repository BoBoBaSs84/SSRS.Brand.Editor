using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Moq;

using SSRS.Brand.Editor.Infrastructure.Installer;

namespace SSRS.Brand.Editor.Infrastructure.Tests.Installer;
[TestClass]
public class DependencyInjectionInstallerTests
{
	[TestMethod]
	public void RegisterInfrastructureServicesTest()
	{
		Mock<IHostEnvironment> hostEnvironmentMock = new Mock<IHostEnvironment>()
			.SetupAllProperties();
		ServiceCollection services = new();

		services.RegisterInfrastructureServices(hostEnvironmentMock.Object);

		Assert.AreEqual(32, services.Count);
	}
}
