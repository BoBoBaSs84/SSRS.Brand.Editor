using SSRS.Brand.Editor.Infrastructure.Providers;
using SSRS.Brand.Editor.Infrastructure.Services;

namespace SSRS.Brand.Editor.Infrastructure.Tests.Services;

[TestClass]
public sealed class ProviderServiceTests : InfrastructureTestBase
{
	[TestMethod]
	public void ProviderServiceConstructorShouldSetUpAllProperties()
	{
		ProviderService? service;

		service = new ProviderService();

		Assert.IsNotNull(service, "ProviderService should not be null after construction.");
		Assert.IsInstanceOfType<DateTimeProvider>(service.DateTime, "DateTime provider should be of type DateTimeProvider.");
		Assert.IsInstanceOfType<DirectoryProvider>(service.Directory, "Directory provider should be of type DirectoryProvider.");
		Assert.IsInstanceOfType<FileProvider>(service.File, "File provider should be of type FileProvider.");
	}
}
