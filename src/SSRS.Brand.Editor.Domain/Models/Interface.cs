using System.Text.Json.Serialization;

using SSRS.Brand.Editor.Domain.Interfaces.Models;

namespace SSRS.Brand.Editor.Domain.Models;

public sealed class Interface : IInterface
{
	public Interface(string primary, string primaryAlt, string primaryAlt2, string primaryAlt3, string primaryAlt4, string primaryContrast, string secondary, string secondaryAlt, string secondaryAlt2, string secondaryAlt3, string secondaryContrast, string neutralPrimary, string neutralPrimaryAlt, string neutralPrimaryAlt2, string neutralPrimaryAlt3, string neutralPrimaryContrast, string neutralSecondary, string neutralSecondaryAlt, string neutralSecondaryAlt2, string neutralSecondaryAlt3, string neutralSecondaryContrast, string neutralTertiary, string neutralTertiaryAlt, string neutralTertiaryAlt2, string neutralTertiaryAlt3, string neutralTertiaryContrast, string danger, string success, string warning, string info, string dangerContrast, string successContrast, string warningContrast, string infoContrast, string kpiGood, string kpiBad, string kpiNeutral, string kpiNone, string kpiGoodContrast, string kpiBadContrast, string kpiNeutralContrast, string kpiNoneContrast)
	{
		Primary = primary;
		PrimaryAlt = primaryAlt;
		PrimaryAlt2 = primaryAlt2;
		PrimaryAlt3 = primaryAlt3;
		PrimaryAlt4 = primaryAlt4;
		PrimaryContrast = primaryContrast;
		Secondary = secondary;
		SecondaryAlt = secondaryAlt;
		SecondaryAlt2 = secondaryAlt2;
		SecondaryAlt3 = secondaryAlt3;
		SecondaryContrast = secondaryContrast;
		NeutralPrimary = neutralPrimary;
		NeutralPrimaryAlt = neutralPrimaryAlt;
		NeutralPrimaryAlt2 = neutralPrimaryAlt2;
		NeutralPrimaryAlt3 = neutralPrimaryAlt3;
		NeutralPrimaryContrast = neutralPrimaryContrast;
		NeutralSecondary = neutralSecondary;
		NeutralSecondaryAlt = neutralSecondaryAlt;
		NeutralSecondaryAlt2 = neutralSecondaryAlt2;
		NeutralSecondaryAlt3 = neutralSecondaryAlt3;
		NeutralSecondaryContrast = neutralSecondaryContrast;
		NeutralTertiary = neutralTertiary;
		NeutralTertiaryAlt = neutralTertiaryAlt;
		NeutralTertiaryAlt2 = neutralTertiaryAlt2;
		NeutralTertiaryAlt3 = neutralTertiaryAlt3;
		NeutralTertiaryContrast = neutralTertiaryContrast;
		Danger = danger;
		Success = success;
		Warning = warning;
		Info = info;
		DangerContrast = dangerContrast;
		SuccessContrast = successContrast;
		WarningContrast = warningContrast;
		InfoContrast = infoContrast;
		KpiGood = kpiGood;
		KpiBad = kpiBad;
		KpiNeutral = kpiNeutral;
		KpiNone = kpiNone;
		KpiGoodContrast = kpiGoodContrast;
		KpiBadContrast = kpiBadContrast;
		KpiNeutralContrast = kpiNeutralContrast;
		KpiNoneContrast = kpiNoneContrast;
	}

	public Interface(IInterface @interface)
	{
		Primary = @interface.Primary;
		PrimaryAlt = @interface.PrimaryAlt;
		PrimaryAlt2 = @interface.PrimaryAlt2;
		PrimaryAlt3 = @interface.PrimaryAlt3;
		PrimaryAlt4 = @interface.PrimaryAlt4;
		PrimaryContrast = @interface.PrimaryContrast;
		Secondary = @interface.Secondary;
		SecondaryAlt = @interface.SecondaryAlt;
		SecondaryAlt2 = @interface.SecondaryAlt2;
		SecondaryAlt3 = @interface.SecondaryAlt3;
		SecondaryContrast = @interface.SecondaryContrast;
		NeutralPrimary = @interface.NeutralPrimary;
		NeutralPrimaryAlt = @interface.NeutralPrimaryAlt;
		NeutralPrimaryAlt2 = @interface.NeutralPrimaryAlt2;
		NeutralPrimaryAlt3 = @interface.NeutralPrimaryAlt3;
		NeutralPrimaryContrast = @interface.NeutralPrimaryContrast;
		NeutralSecondary = @interface.NeutralSecondary;
		NeutralSecondaryAlt = @interface.NeutralSecondaryAlt;
		NeutralSecondaryAlt2 = @interface.NeutralSecondaryAlt2;
		NeutralSecondaryAlt3 = @interface.NeutralSecondaryAlt3;
		NeutralSecondaryContrast = @interface.NeutralSecondaryContrast;
		NeutralTertiaryAlt = @interface.NeutralTertiaryAlt;
		NeutralTertiaryAlt2 = @interface.NeutralTertiaryAlt2;
		NeutralTertiaryAlt3 = @interface.NeutralTertiaryAlt3;
		NeutralTertiaryContrast = @interface.NeutralTertiaryContrast;
		Danger = @interface.Danger;
		Success = @interface.Success;
		Warning = @interface.Warning;
		Info = @interface.Info;
		DangerContrast = @interface.DangerContrast;
		SuccessContrast = @interface.SuccessContrast;
		WarningContrast = @interface.WarningContrast;
		InfoContrast = @interface.InfoContrast;
		KpiGood = @interface.KpiGood;
		KpiBad = @interface.KpiBad;
		KpiNeutral = @interface.KpiNeutral;
		KpiNone = @interface.KpiNone;
		KpiGoodContrast = @interface.KpiGoodContrast;
		KpiBadContrast = @interface.KpiBadContrast;
		KpiNeutralContrast = @interface.KpiNeutralContrast;
		KpiNoneContrast = @interface.KpiNoneContrast;
	}

	[JsonPropertyName("primary")]
	public string Primary { get; set; }

	[JsonPropertyName("primaryAlt")]
	public string PrimaryAlt { get; set; }

	[JsonPropertyName("primaryAlt2")]
	public string PrimaryAlt2 { get; set; }

	[JsonPropertyName("primaryAlt3")]
	public string PrimaryAlt3 { get; set; }

	[JsonPropertyName("primaryAlt4")]
	public string PrimaryAlt4 { get; set; }

	[JsonPropertyName("primaryContrast")]
	public string PrimaryContrast { get; set; }

	[JsonPropertyName("secondary")]
	public string Secondary { get; set; }

	[JsonPropertyName("secondaryAlt")]
	public string SecondaryAlt { get; set; }

	[JsonPropertyName("secondaryAlt2")]
	public string SecondaryAlt2 { get; set; }

	[JsonPropertyName("secondaryAlt3")]
	public string SecondaryAlt3 { get; set; }

	[JsonPropertyName("secondaryContrast")]
	public string SecondaryContrast { get; set; }

	[JsonPropertyName("neutralPrimary")]
	public string NeutralPrimary { get; set; }

	[JsonPropertyName("neutralPrimaryAlt")]
	public string NeutralPrimaryAlt { get; set; }

	[JsonPropertyName("neutralPrimaryAlt2")]
	public string NeutralPrimaryAlt2 { get; set; }

	[JsonPropertyName("neutralPrimaryAlt3")]
	public string NeutralPrimaryAlt3 { get; set; }

	[JsonPropertyName("neutralPrimaryContrast")]
	public string NeutralPrimaryContrast { get; set; }

	[JsonPropertyName("neutralSecondary")]
	public string NeutralSecondary { get; set; }

	[JsonPropertyName("neutralSecondaryAlt")]
	public string NeutralSecondaryAlt { get; set; }

	[JsonPropertyName("neutralSecondaryAlt2")]
	public string NeutralSecondaryAlt2 { get; set; }

	[JsonPropertyName("neutralSecondaryAlt3")]
	public string NeutralSecondaryAlt3 { get; set; }

	[JsonPropertyName("neutralSecondaryContrast")]
	public string NeutralSecondaryContrast { get; set; }

	[JsonPropertyName("neutralTertiary")]
	public string NeutralTertiary { get; set; }

	[JsonPropertyName("neutralTertiaryAlt")]
	public string NeutralTertiaryAlt { get; set; }

	[JsonPropertyName("neutralTertiaryAlt2")]
	public string NeutralTertiaryAlt2 { get; set; }

	[JsonPropertyName("neutralTertiaryAlt3")]
	public string NeutralTertiaryAlt3 { get; set; }

	[JsonPropertyName("neutralTertiaryContrast")]
	public string NeutralTertiaryContrast { get; set; }

	[JsonPropertyName("danger")]
	public string Danger { get; set; }

	[JsonPropertyName("success")]
	public string Success { get; set; }

	[JsonPropertyName("warning")]
	public string Warning { get; set; }

	[JsonPropertyName("info")]
	public string Info { get; set; }

	[JsonPropertyName("dangerContrast")]
	public string DangerContrast { get; set; }

	[JsonPropertyName("successContrast")]
	public string SuccessContrast { get; set; }

	[JsonPropertyName("warningContrast")]
	public string WarningContrast { get; set; }

	[JsonPropertyName("infoContrast")]
	public string InfoContrast { get; set; }

	[JsonPropertyName("kpiGood")]
	public string KpiGood { get; set; }

	[JsonPropertyName("kpiBad")]
	public string KpiBad { get; set; }

	[JsonPropertyName("kpiNeutral")]
	public string KpiNeutral { get; set; }

	[JsonPropertyName("kpiNone")]
	public string KpiNone { get; set; }

	[JsonPropertyName("kpiGoodContrast")]
	public string KpiGoodContrast { get; set; }

	[JsonPropertyName("kpiBadContrast")]
	public string KpiBadContrast { get; set; }

	[JsonPropertyName("kpiNeutralContrast")]
	public string KpiNeutralContrast { get; set; }

	[JsonPropertyName("kpiNoneContrast")]
	public string KpiNoneContrast { get; set; }
}
