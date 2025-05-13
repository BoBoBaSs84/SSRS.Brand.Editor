using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SSRS.Brand.Editor.Application.Installer;

namespace SSRS.Brand.Editor.Application.Tests.Installer;
[TestClass]
public class DependencyInjectionInstallerTests
{
	[TestMethod]
	public void RegisterApplicationServicesTest()
	{
		ServiceCollection services = new();

		services.RegisterApplicationServices();

		Assert.AreEqual(3, services.Count);
	}
}
