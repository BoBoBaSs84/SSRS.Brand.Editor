using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Presentation.Installer;

namespace SSRS.Brand.Editor.Presentation.Tests.Installer;

[TestClass]
public sealed class DependencyInjectionInstallerTests
{
	[TestMethod]
	public void RegisterPresentationServicesTest()
	{
		ServiceCollection services = new();

		services.RegisterPresentationServices();

		Assert.AreEqual(6, services.Count);
	}
}
