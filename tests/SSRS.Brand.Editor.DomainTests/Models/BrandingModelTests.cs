using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.DomainTests.Models;

[TestClass]
public sealed class BrandingModelTests : DomainTestBase
{
	[TestMethod]
	public void BrandingModelTest()
	{
		BrandingModel? model;

		model = new();

		Assert.IsNotNull(model);
		Assert.IsNotNull(model.Colors);
		Assert.IsNotNull(model.Metadata);
	}
}
