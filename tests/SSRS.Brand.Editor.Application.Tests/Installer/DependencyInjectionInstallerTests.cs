using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Application.Installers;

namespace SSRS.Brand.Editor.Application.Tests.Installer;

[TestClass]
public sealed class DependencyInjectionInstallerTests : ApplicationTestBase
{
	[TestMethod]
	public void RegisterApplicationServicesTest()
	{
		ServiceCollection services = new();

		services.RegisterApplicationServices();

		Assert.AreEqual(6, services.Count);
	}
}
