using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Tests.Models;

[TestClass]
public sealed class BrandPackageModelTests
{
	[TestMethod]
	public void ConstructorShouldCreateInstanceWithChildren()
	{
		BrandPackageModel model;

		model = new BrandPackageModel();

		Assert.IsNotNull(model);
		Assert.IsNotNull(model.Metadata);
		Assert.IsNotNull(model.ColorScheme);
		Assert.IsNull(model.Logo);
		Assert.IsFalse(model.Metadata.HasLogo);
	}

	[TestMethod]
	public void LogoPropertyShouldRaisePropertyChanged()
	{
		BrandPackageModel model = new();
		bool raised = false;
		model.PropertyChanged += (s, e) =>
		{
			if (e.PropertyName == nameof(BrandPackageModel.Logo))
				raised = true;
		};

		model.Logo = [0x89, 0x50, 0x4E, 0x47];

		Assert.IsTrue(raised);
		Assert.IsNotNull(model.Logo);
		Assert.AreEqual(4, model.Logo.Length);
	}

	[TestMethod]
	public void SettingLogoShouldUpdateMetadataHasLogo()
	{
		BrandPackageModel model = new();

		Assert.IsFalse(model.Metadata.HasLogo);

		model.Logo = [0x89, 0x50, 0x4E, 0x47];

		Assert.IsTrue(model.Metadata.HasLogo);
	}

	[TestMethod]
	public void ClearingLogoShouldUpdateMetadataHasLogo()
	{
		BrandPackageModel model = new();
		model.Logo = [0x89, 0x50, 0x4E, 0x47];

		Assert.IsTrue(model.Metadata.HasLogo);

		model.Logo = null;

		Assert.IsFalse(model.Metadata.HasLogo);
	}

	[TestMethod]
	public void SettingEmptyLogoShouldUpdateMetadataHasLogoToFalse()
	{
		BrandPackageModel model = new();
		model.Logo = [0x89, 0x50, 0x4E, 0x47];

		Assert.IsTrue(model.Metadata.HasLogo);

		model.Logo = [];

		Assert.IsFalse(model.Metadata.HasLogo);
	}
}
