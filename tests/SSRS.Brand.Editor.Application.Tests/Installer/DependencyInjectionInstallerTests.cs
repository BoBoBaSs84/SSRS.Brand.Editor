using SSRS.Brand.Editor.Application.Installers;

using Microsoft.Extensions.DependencyInjection;

namespace SSRS.Brand.Editor.Application.Tests.Installer;

[TestClass]
public sealed class DependencyInjectionInstallerTests : ApplicationTestBase
{
	[TestMethod]
	public void RegisterApplicationServicesTest()
	{
		ServiceCollection services = new();

		services.RegisterApplicationServices();

		Assert.AreEqual(5, services.Count);
	}
}
