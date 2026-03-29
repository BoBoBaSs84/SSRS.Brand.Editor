using SSRS.Brand.Editor.Domain.Installers;

using Microsoft.Extensions.DependencyInjection;

namespace SSRS.Brand.Editor.Domain.Tests.Installer;

[TestClass]
public sealed class DependencyInjectionInstallerTests
{
	[TestMethod]
	public void RegisterDomainServicesTest()
	{
		ServiceCollection services = new();

		services.RegisterDomainServices();

		Assert.AreEqual(1, services.Count);
	}
}
