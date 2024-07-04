using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.DomainTests.Models;

[TestClass]
public sealed class BrandingModelTests : DomainTestBase
{
	[TestMethod]
	public void BrandingModelRegisterTest()
	{
		BrandingModel? model;

		model = new BrandingModel();

		Assert.IsNotNull(model);
		Assert.IsNotNull(model.Colors);
		Assert.IsNotNull(model.Metadata);
	}

	[TestMethod]
	public void BrandingModelConstructorTest()
	{
		BrandingModel? model;

		model = new()
		{
			Colors = new ColorsModel(),
			Metadata = new MetadataModel()
		};

		Assert.IsNotNull(model);
		Assert.IsNotNull(model.Colors);
		Assert.IsNotNull(model.Metadata);
	}
}
