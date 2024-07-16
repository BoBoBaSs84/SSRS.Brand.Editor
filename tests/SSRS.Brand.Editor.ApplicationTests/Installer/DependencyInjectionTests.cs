using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Application.Installer;

namespace SSRS.Brand.Editor.Application.Tests.Installer;

[TestClass]
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, unit test.")]
public sealed class DependencyInjectionTests : ApplicationTestBase
{
	[TestMethod]
	[TestCategory("DependencyInjection")]
	public void RegisterApplicationServicesTest()
	{
		IServiceCollection services = new ServiceCollection();

		services.RegisterApplicationServices();

		Assert.AreEqual(4, services.Count);
	}
}
