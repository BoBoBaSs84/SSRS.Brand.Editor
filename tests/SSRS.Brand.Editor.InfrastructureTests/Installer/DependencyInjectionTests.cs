using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Moq;

using SSRS.Brand.Editor.Infrastructure.Installer;

namespace SSRS.Brand.Editor.Infrastructure.Tests.Installer;

[TestClass]
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, unit test.")]
public class DependencyInjectionTests : InfrastructureTestBase
{
	[TestMethod]
	[TestCategory("DependencyInjection")]
	public void RegisterInfrastructureServicesTest()
	{
		Mock<IHostEnvironment> env = new Mock<IHostEnvironment>()
			.SetupAllProperties();
		env.Setup(x => x.EnvironmentName).Returns("Development");
		IServiceCollection services = new ServiceCollection();

		services.RegisterInfrastructureServices(env.Object);

		Assert.AreEqual(12, services.Count);
	}
}
