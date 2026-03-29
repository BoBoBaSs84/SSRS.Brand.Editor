using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Domain.Installers;

namespace SSRS.Brand.Editor.Domain.Tests.Installer;

[TestClass]
public sealed class DependencyInjectionInstallerTests
{
	[TestMethod]
	public void RegisterDomainServicesTest()
	{
		ServiceCollection services = new();

		services.RegisterDomainServices();

		Assert.AreEqual(2, services.Count);
	}
}
