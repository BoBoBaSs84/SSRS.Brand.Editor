using Microsoft.Extensions.DependencyInjection;

using SSRS.Brand.Editor.Domain.Installer;

namespace SSRS.Brand.Editor.Domain.Tests.Installer;

[TestClass]
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, unit test.")]
public sealed class DependencyInjectionTests : DomainTestBase
{
	[TestMethod]
	[TestCategory("DependencyInjection")]
	public void RegisterDomainServicesTest()
	{
		IServiceCollection services = new ServiceCollection();

		services.RegisterDomainServices();

		Assert.AreEqual(1, services.Count);
	}
}
