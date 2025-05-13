using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SSRS.Brand.Editor.Domain.Installer;

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
