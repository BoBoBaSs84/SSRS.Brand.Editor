using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Presentation.Installers;

namespace SSRS.Brand.Editor.Presentation.Tests.Installers;

[TestClass]
public sealed class DependencyInjectionInstallerTests : PresentationTestBase
{
	[TestMethod]
	public void RegisterPresentationServicesTest()
	{
		ServiceCollection services = new();

		services.RegisterPresentationServices();

		Assert.AreEqual(5, services.Count);
	}
}
