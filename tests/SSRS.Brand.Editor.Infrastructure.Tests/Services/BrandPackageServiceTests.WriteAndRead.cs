using System.Drawing;

using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Infrastructure.Tests.Services;

public sealed partial class BrandPackageServiceTests
{
	[TestMethod]
	public async Task WriteAsyncShouldCreateZipFile()
	{
		string filePath = GetTempFilePath();
		BrandPackageModel model = CreateTestModel();

		await _sut.WriteAsync(filePath, model);

		Assert.IsTrue(File.Exists(filePath));
	}

	[TestMethod]
	public async Task WriteAsyncWithLogoShouldCreateZipFile()
	{
		string filePath = GetTempFilePath();
		BrandPackageModel model = CreateTestModel();
		model.Logo = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A];

		await _sut.WriteAsync(filePath, model);

		Assert.IsTrue(File.Exists(filePath));
	}

	[TestMethod]
	public async Task WriteAndReadRoundTripShouldPreserveMetadata()
	{
		string filePath = GetTempFilePath();
		BrandPackageModel original = CreateTestModel();

		await _sut.WriteAsync(filePath, original);
		BrandPackageModel result = await _sut.ReadAsync(filePath);

		Assert.AreEqual(original.Metadata.Name, result.Metadata.Name);
		Assert.AreEqual(original.Metadata.Version, result.Metadata.Version);
		Assert.AreEqual(original.Metadata.HasLogo, result.Metadata.HasLogo);
	}

	[TestMethod]
	public async Task WriteAndReadRoundTripShouldPreserveColorSchemeName()
	{
		string filePath = GetTempFilePath();
		BrandPackageModel original = CreateTestModel();

		await _sut.WriteAsync(filePath, original);
		BrandPackageModel result = await _sut.ReadAsync(filePath);

		Assert.AreEqual(original.ColorScheme.Name, result.ColorScheme.Name);
		Assert.AreEqual(original.ColorScheme.Version, result.ColorScheme.Version);
	}

	[TestMethod]
	public async Task WriteAndReadRoundTripShouldPreserveInterfaceColors()
	{
		string filePath = GetTempFilePath();
		BrandPackageModel original = CreateTestModel();

		await _sut.WriteAsync(filePath, original);
		BrandPackageModel result = await _sut.ReadAsync(filePath);

		Assert.AreEqual(original.ColorScheme.Interface.Primary.ToArgb(), result.ColorScheme.Interface.Primary.ToArgb());
		Assert.AreEqual(original.ColorScheme.Interface.PrimaryContrast.ToArgb(), result.ColorScheme.Interface.PrimaryContrast.ToArgb());
		Assert.AreEqual(original.ColorScheme.Interface.Secondary.ToArgb(), result.ColorScheme.Interface.Secondary.ToArgb());
		Assert.AreEqual(original.ColorScheme.Interface.Danger.ToArgb(), result.ColorScheme.Interface.Danger.ToArgb());
		Assert.AreEqual(original.ColorScheme.Interface.KpiGood.ToArgb(), result.ColorScheme.Interface.KpiGood.ToArgb());
		Assert.AreEqual(original.ColorScheme.Interface.PrimaryButton.ToArgb(), result.ColorScheme.Interface.PrimaryButton.ToArgb());
		Assert.AreEqual(original.ColorScheme.Interface.Link.ToArgb(), result.ColorScheme.Interface.Link.ToArgb());
		Assert.AreEqual(original.ColorScheme.Interface.RadioButtonCheckBox.ToArgb(), result.ColorScheme.Interface.RadioButtonCheckBox.ToArgb());
	}

	[TestMethod]
	public async Task WriteAndReadRoundTripShouldPreserveThemeColors()
	{
		string filePath = GetTempFilePath();
		BrandPackageModel original = CreateTestModel();

		await _sut.WriteAsync(filePath, original);
		BrandPackageModel result = await _sut.ReadAsync(filePath);

		Assert.AreEqual(original.ColorScheme.Theme.Good.ToArgb(), result.ColorScheme.Theme.Good.ToArgb());
		Assert.AreEqual(original.ColorScheme.Theme.Bad.ToArgb(), result.ColorScheme.Theme.Bad.ToArgb());
		Assert.AreEqual(original.ColorScheme.Theme.Background.ToArgb(), result.ColorScheme.Theme.Background.ToArgb());
		Assert.AreEqual(original.ColorScheme.Theme.PanelAccent.ToArgb(), result.ColorScheme.Theme.PanelAccent.ToArgb());
		Assert.AreEqual(original.ColorScheme.Theme.AltTableAccent.ToArgb(), result.ColorScheme.Theme.AltTableAccent.ToArgb());
	}

	[TestMethod]
	public async Task WriteAndReadRoundTripShouldPreserveDataPoints()
	{
		string filePath = GetTempFilePath();
		BrandPackageModel original = CreateTestModel();

		await _sut.WriteAsync(filePath, original);
		BrandPackageModel result = await _sut.ReadAsync(filePath);

		Assert.AreEqual(original.ColorScheme.Theme.DataPoints.Count, result.ColorScheme.Theme.DataPoints.Count);
		for (int i = 0; i < original.ColorScheme.Theme.DataPoints.Count; i++)
			Assert.AreEqual(original.ColorScheme.Theme.DataPoints[i].ToArgb(), result.ColorScheme.Theme.DataPoints[i].ToArgb());
	}

	[TestMethod]
	public async Task WriteAndReadRoundTripShouldPreserveLogo()
	{
		string filePath = GetTempFilePath();
		BrandPackageModel original = CreateTestModel();
		byte[] logoBytes = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x01, 0x02, 0x03];
		original.Logo = logoBytes;

		await _sut.WriteAsync(filePath, original);
		BrandPackageModel result = await _sut.ReadAsync(filePath);

		Assert.IsTrue(result.Metadata.HasLogo);
		Assert.IsNotNull(result.Logo);
		CollectionAssert.AreEqual(logoBytes, result.Logo);
	}

	[TestMethod]
	public async Task WriteAndReadRoundTripWithoutLogoShouldHaveNoLogo()
	{
		string filePath = GetTempFilePath();
		BrandPackageModel original = CreateTestModel();

		await _sut.WriteAsync(filePath, original);
		BrandPackageModel result = await _sut.ReadAsync(filePath);

		Assert.IsFalse(result.Metadata.HasLogo);
		Assert.IsNull(result.Logo);
	}

	[TestMethod]
	public async Task ReadAsyncShouldThrowForMissingFile()
	{
		string filePath = GetTempFilePath("nonexistent.zip");

		await Assert.ThrowsExactlyAsync<FileNotFoundException>(
			() => _sut.ReadAsync(filePath));
	}

	private static BrandPackageModel CreateTestModel()
	{
		BrandPackageModel model = new();

		model.Metadata.Name = "Test Brand";
		model.Metadata.Version = "2.0.2";

		model.ColorScheme.Name = "Test Brand";
		model.ColorScheme.Version = "1.0";

		model.ColorScheme.Interface.Primary = Color.FromArgb(187, 33, 36);
		model.ColorScheme.Interface.PrimaryAlt = Color.FromArgb(211, 17, 21);
		model.ColorScheme.Interface.PrimaryAlt2 = Color.FromArgb(103, 18, 21);
		model.ColorScheme.Interface.PrimaryAlt3 = Color.FromArgb(187, 33, 36);
		model.ColorScheme.Interface.PrimaryAlt4 = Color.FromArgb(0, 171, 238);
		model.ColorScheme.Interface.PrimaryContrast = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.Secondary = Color.FromArgb(0, 0, 0);
		model.ColorScheme.Interface.SecondaryAlt = Color.FromArgb(68, 68, 68);
		model.ColorScheme.Interface.SecondaryAlt2 = Color.FromArgb(85, 85, 85);
		model.ColorScheme.Interface.SecondaryAlt3 = Color.FromArgb(119, 119, 119);
		model.ColorScheme.Interface.SecondaryContrast = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.NeutralPrimary = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.NeutralPrimaryAlt = Color.FromArgb(244, 244, 244);
		model.ColorScheme.Interface.NeutralPrimaryAlt2 = Color.FromArgb(227, 227, 227);
		model.ColorScheme.Interface.NeutralPrimaryAlt3 = Color.FromArgb(200, 200, 200);
		model.ColorScheme.Interface.NeutralPrimaryContrast = Color.FromArgb(0, 0, 0);
		model.ColorScheme.Interface.NeutralSecondary = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.NeutralSecondaryAlt = Color.FromArgb(234, 234, 234);
		model.ColorScheme.Interface.NeutralSecondaryAlt2 = Color.FromArgb(183, 183, 183);
		model.ColorScheme.Interface.NeutralSecondaryAlt3 = Color.FromArgb(172, 172, 172);
		model.ColorScheme.Interface.NeutralSecondaryContrast = Color.FromArgb(0, 0, 0);
		model.ColorScheme.Interface.NeutralTertiary = Color.FromArgb(183, 183, 183);
		model.ColorScheme.Interface.NeutralTertiaryAlt = Color.FromArgb(200, 200, 200);
		model.ColorScheme.Interface.NeutralTertiaryAlt2 = Color.FromArgb(234, 234, 234);
		model.ColorScheme.Interface.NeutralTertiaryAlt3 = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.NeutralTertiaryContrast = Color.FromArgb(34, 34, 34);
		model.ColorScheme.Interface.Danger = Color.FromArgb(187, 33, 36);
		model.ColorScheme.Interface.Success = Color.FromArgb(34, 187, 51);
		model.ColorScheme.Interface.Warning = Color.FromArgb(240, 173, 78);
		model.ColorScheme.Interface.Info = Color.FromArgb(91, 192, 222);
		model.ColorScheme.Interface.DangerContrast = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.SuccessContrast = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.WarningContrast = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.InfoContrast = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.KpiGood = Color.FromArgb(79, 180, 67);
		model.ColorScheme.Interface.KpiBad = Color.FromArgb(222, 6, 26);
		model.ColorScheme.Interface.KpiNeutral = Color.FromArgb(217, 180, 44);
		model.ColorScheme.Interface.KpiNone = Color.FromArgb(51, 51, 51);
		model.ColorScheme.Interface.KpiGoodContrast = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.KpiBadContrast = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.KpiNeutralContrast = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.KpiNoneContrast = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.ItemTypeIconColor = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Interface.ReportIconBackground = Color.FromArgb(18, 35, 158);
		model.ColorScheme.Interface.ExcelIconBackground = Color.FromArgb(33, 115, 70);
		model.ColorScheme.Interface.FolderIconBackground = Color.FromArgb(70, 104, 197);
		model.ColorScheme.Interface.DatasetIconBackground = Color.FromArgb(201, 79, 15);
		model.ColorScheme.Interface.OtherIconBackground = Color.FromArgb(0, 0, 0);
		model.ColorScheme.Interface.PrimaryButton = Color.FromArgb(187, 33, 36);
		model.ColorScheme.Interface.PrimaryButtonHover = Color.FromArgb(211, 17, 21);
		model.ColorScheme.Interface.PrimaryButtonPressed = Color.FromArgb(61, 0, 0);
		model.ColorScheme.Interface.Link = Color.FromArgb(211, 17, 21);
		model.ColorScheme.Interface.LinkHover = Color.FromArgb(103, 18, 21);
		model.ColorScheme.Interface.LinkVisited = Color.FromArgb(61, 0, 0);
		model.ColorScheme.Interface.RadioButtonCheckBox = Color.FromArgb(187, 33, 36);
		model.ColorScheme.Interface.RadioButtonCheckBoxHover = Color.FromArgb(211, 17, 21);

		model.ColorScheme.Theme.DataPoints.Add(Color.FromArgb(0, 114, 198));
		model.ColorScheme.Theme.DataPoints.Add(Color.FromArgb(246, 140, 31));
		model.ColorScheme.Theme.DataPoints.Add(Color.FromArgb(38, 150, 87));
		model.ColorScheme.Theme.Good = Color.FromArgb(133, 186, 0);
		model.ColorScheme.Theme.Bad = Color.FromArgb(233, 0, 0);
		model.ColorScheme.Theme.Neutral = Color.FromArgb(237, 179, 39);
		model.ColorScheme.Theme.None = Color.FromArgb(51, 51, 51);
		model.ColorScheme.Theme.Background = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Theme.Foreground = Color.FromArgb(34, 34, 34);
		model.ColorScheme.Theme.MapBase = Color.FromArgb(0, 174, 239);
		model.ColorScheme.Theme.PanelBackground = Color.FromArgb(246, 246, 246);
		model.ColorScheme.Theme.PanelForeground = Color.FromArgb(34, 34, 34);
		model.ColorScheme.Theme.PanelAccent = Color.FromArgb(0, 174, 239);
		model.ColorScheme.Theme.TableAccent = Color.FromArgb(0, 174, 239);
		model.ColorScheme.Theme.AltBackground = Color.FromArgb(246, 246, 246);
		model.ColorScheme.Theme.AltForeground = Color.FromArgb(0, 0, 0);
		model.ColorScheme.Theme.AltMapBase = Color.FromArgb(246, 140, 31);
		model.ColorScheme.Theme.AltPanelBackground = Color.FromArgb(35, 83, 120);
		model.ColorScheme.Theme.AltPanelForeground = Color.FromArgb(255, 255, 255);
		model.ColorScheme.Theme.AltPanelAccent = Color.FromArgb(253, 195, 54);
		model.ColorScheme.Theme.AltTableAccent = Color.FromArgb(253, 195, 54);

		return model;
	}
}
