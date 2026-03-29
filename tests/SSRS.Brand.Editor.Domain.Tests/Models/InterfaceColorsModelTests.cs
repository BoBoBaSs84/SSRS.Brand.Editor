using System.Drawing;

using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Tests.Models;

[TestClass]
public sealed class InterfaceColorsModelTests
{
	[TestMethod]
	public void ConstructorShouldCreateInstance()
	{
		InterfaceColorsModel model;

		model = new InterfaceColorsModel();

		Assert.IsNotNull(model);
	}

	[TestMethod]
	public void PrimaryPropertiesShouldRaisePropertyChanged()
	{
		InterfaceColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.Primary = Color.Red;
		model.PrimaryAlt = Color.DarkRed;
		model.PrimaryAlt2 = Color.OrangeRed;
		model.PrimaryAlt3 = Color.IndianRed;
		model.PrimaryAlt4 = Color.MediumVioletRed;
		model.PrimaryContrast = Color.White;

		Assert.AreEqual(6, changedProperties.Count);
		Assert.AreEqual(Color.Red, model.Primary);
		Assert.AreEqual(Color.DarkRed, model.PrimaryAlt);
		Assert.AreEqual(Color.OrangeRed, model.PrimaryAlt2);
		Assert.AreEqual(Color.IndianRed, model.PrimaryAlt3);
		Assert.AreEqual(Color.MediumVioletRed, model.PrimaryAlt4);
		Assert.AreEqual(Color.White, model.PrimaryContrast);
	}

	[TestMethod]
	public void SecondaryPropertiesShouldRaisePropertyChanged()
	{
		InterfaceColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.Secondary = Color.Black;
		model.SecondaryAlt = Color.DarkGray;
		model.SecondaryAlt2 = Color.Gray;
		model.SecondaryAlt3 = Color.LightGray;
		model.SecondaryContrast = Color.White;

		Assert.AreEqual(5, changedProperties.Count);
		Assert.AreEqual(Color.Black, model.Secondary);
		Assert.AreEqual(Color.DarkGray, model.SecondaryAlt);
		Assert.AreEqual(Color.Gray, model.SecondaryAlt2);
		Assert.AreEqual(Color.LightGray, model.SecondaryAlt3);
		Assert.AreEqual(Color.White, model.SecondaryContrast);
	}

	[TestMethod]
	public void NeutralPrimaryPropertiesShouldRaisePropertyChanged()
	{
		InterfaceColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.NeutralPrimary = Color.White;
		model.NeutralPrimaryAlt = Color.WhiteSmoke;
		model.NeutralPrimaryAlt2 = Color.Gainsboro;
		model.NeutralPrimaryAlt3 = Color.Silver;
		model.NeutralPrimaryContrast = Color.Black;

		Assert.AreEqual(5, changedProperties.Count);
		Assert.AreEqual(Color.White, model.NeutralPrimary);
		Assert.AreEqual(Color.WhiteSmoke, model.NeutralPrimaryAlt);
		Assert.AreEqual(Color.Gainsboro, model.NeutralPrimaryAlt2);
		Assert.AreEqual(Color.Silver, model.NeutralPrimaryAlt3);
		Assert.AreEqual(Color.Black, model.NeutralPrimaryContrast);
	}

	[TestMethod]
	public void NeutralSecondaryPropertiesShouldRaisePropertyChanged()
	{
		InterfaceColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.NeutralSecondary = Color.White;
		model.NeutralSecondaryAlt = Color.Lavender;
		model.NeutralSecondaryAlt2 = Color.LightSteelBlue;
		model.NeutralSecondaryAlt3 = Color.LightSlateGray;
		model.NeutralSecondaryContrast = Color.Black;

		Assert.AreEqual(5, changedProperties.Count);
		Assert.AreEqual(Color.White, model.NeutralSecondary);
		Assert.AreEqual(Color.Lavender, model.NeutralSecondaryAlt);
		Assert.AreEqual(Color.LightSteelBlue, model.NeutralSecondaryAlt2);
		Assert.AreEqual(Color.LightSlateGray, model.NeutralSecondaryAlt3);
		Assert.AreEqual(Color.Black, model.NeutralSecondaryContrast);
	}

	[TestMethod]
	public void NeutralTertiaryPropertiesShouldRaisePropertyChanged()
	{
		InterfaceColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.NeutralTertiary = Color.Silver;
		model.NeutralTertiaryAlt = Color.DarkGray;
		model.NeutralTertiaryAlt2 = Color.LightGray;
		model.NeutralTertiaryAlt3 = Color.White;
		model.NeutralTertiaryContrast = Color.DimGray;

		Assert.AreEqual(5, changedProperties.Count);
		Assert.AreEqual(Color.Silver, model.NeutralTertiary);
		Assert.AreEqual(Color.DarkGray, model.NeutralTertiaryAlt);
		Assert.AreEqual(Color.LightGray, model.NeutralTertiaryAlt2);
		Assert.AreEqual(Color.White, model.NeutralTertiaryAlt3);
		Assert.AreEqual(Color.DimGray, model.NeutralTertiaryContrast);
	}

	[TestMethod]
	public void StatusPropertiesShouldRaisePropertyChanged()
	{
		InterfaceColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.Danger = Color.Red;
		model.Success = Color.Green;
		model.Warning = Color.Orange;
		model.Info = Color.CornflowerBlue;
		model.DangerContrast = Color.White;
		model.SuccessContrast = Color.White;
		model.WarningContrast = Color.White;
		model.InfoContrast = Color.White;

		Assert.AreEqual(8, changedProperties.Count);
		Assert.AreEqual(Color.Red, model.Danger);
		Assert.AreEqual(Color.Green, model.Success);
		Assert.AreEqual(Color.Orange, model.Warning);
		Assert.AreEqual(Color.CornflowerBlue, model.Info);
	}

	[TestMethod]
	public void KpiPropertiesShouldRaisePropertyChanged()
	{
		InterfaceColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.KpiGood = Color.Green;
		model.KpiBad = Color.Red;
		model.KpiNeutral = Color.Gold;
		model.KpiNone = Color.DarkGray;
		model.KpiGoodContrast = Color.White;
		model.KpiBadContrast = Color.White;
		model.KpiNeutralContrast = Color.White;
		model.KpiNoneContrast = Color.White;

		Assert.AreEqual(8, changedProperties.Count);
		Assert.AreEqual(Color.Green, model.KpiGood);
		Assert.AreEqual(Color.Red, model.KpiBad);
		Assert.AreEqual(Color.Gold, model.KpiNeutral);
		Assert.AreEqual(Color.DarkGray, model.KpiNone);
	}

	[TestMethod]
	public void IconPropertiesShouldRaisePropertyChanged()
	{
		InterfaceColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.ItemTypeIconColor = Color.White;
		model.ReportIconBackground = Color.Navy;
		model.ExcelIconBackground = Color.DarkGreen;
		model.FolderIconBackground = Color.RoyalBlue;
		model.DatasetIconBackground = Color.DarkOrange;
		model.OtherIconBackground = Color.Black;

		Assert.AreEqual(6, changedProperties.Count);
		Assert.AreEqual(Color.White, model.ItemTypeIconColor);
		Assert.AreEqual(Color.Navy, model.ReportIconBackground);
		Assert.AreEqual(Color.DarkGreen, model.ExcelIconBackground);
		Assert.AreEqual(Color.RoyalBlue, model.FolderIconBackground);
		Assert.AreEqual(Color.DarkOrange, model.DatasetIconBackground);
		Assert.AreEqual(Color.Black, model.OtherIconBackground);
	}

	[TestMethod]
	public void ButtonPropertiesShouldRaisePropertyChanged()
	{
		InterfaceColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.PrimaryButton = Color.Red;
		model.PrimaryButtonHover = Color.DarkRed;
		model.PrimaryButtonPressed = Color.Maroon;

		Assert.AreEqual(3, changedProperties.Count);
		Assert.AreEqual(Color.Red, model.PrimaryButton);
		Assert.AreEqual(Color.DarkRed, model.PrimaryButtonHover);
		Assert.AreEqual(Color.Maroon, model.PrimaryButtonPressed);
	}

	[TestMethod]
	public void LinkPropertiesShouldRaisePropertyChanged()
	{
		InterfaceColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.Link = Color.Blue;
		model.LinkHover = Color.DarkBlue;
		model.LinkVisited = Color.Purple;

		Assert.AreEqual(3, changedProperties.Count);
		Assert.AreEqual(Color.Blue, model.Link);
		Assert.AreEqual(Color.DarkBlue, model.LinkHover);
		Assert.AreEqual(Color.Purple, model.LinkVisited);
	}

	[TestMethod]
	public void ControlPropertiesShouldRaisePropertyChanged()
	{
		InterfaceColorsModel model = new();
		List<string> changedProperties = [];
		model.PropertyChanged += (s, e) => changedProperties.Add(e.PropertyName!);

		model.RadioButtonCheckBox = Color.Red;
		model.RadioButtonCheckBoxHover = Color.DarkRed;

		Assert.AreEqual(2, changedProperties.Count);
		Assert.AreEqual(Color.Red, model.RadioButtonCheckBox);
		Assert.AreEqual(Color.DarkRed, model.RadioButtonCheckBoxHover);
	}
}
