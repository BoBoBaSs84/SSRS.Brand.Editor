using System.Drawing;
using System.Text.Json.Serialization;

using SSRS.Brand.Editor.Domain.Converters;

namespace SSRS.Brand.Editor.Domain.Models;

public sealed class Interface
{
	public Interface()
	{ }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("primary")]
	public Color Primary { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("primaryAlt")]
	public Color PrimaryAlt { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("primaryAlt2")]
	public Color PrimaryAlt2 { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("primaryAlt3")]
	public Color PrimaryAlt3 { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("primaryAlt4")]
	public Color PrimaryAlt4 { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("primaryContrast")]
	public Color PrimaryContrast { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("secondary")]
	public Color Secondary { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("secondaryAlt")]
	public Color SecondaryAlt { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("secondaryAlt2")]
	public Color SecondaryAlt2 { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("secondaryAlt3")]
	public Color SecondaryAlt3 { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("secondaryContrast")]
	public Color SecondaryContrast { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralPrimary")]
	public Color NeutralPrimary { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralPrimaryAlt")]
	public Color NeutralPrimaryAlt { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralPrimaryAlt2")]
	public Color NeutralPrimaryAlt2 { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralPrimaryAlt3")]
	public Color NeutralPrimaryAlt3 { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralPrimaryContrast")]
	public Color NeutralPrimaryContrast { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralSecondary")]
	public Color NeutralSecondary { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralSecondaryAlt")]
	public Color NeutralSecondaryAlt { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralSecondaryAlt2")]
	public Color NeutralSecondaryAlt2 { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralSecondaryAlt3")]
	public Color NeutralSecondaryAlt3 { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralSecondaryContrast")]
	public Color NeutralSecondaryContrast { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralTertiary")]
	public Color NeutralTertiary { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralTertiaryAlt")]
	public Color NeutralTertiaryAlt { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralTertiaryAlt2")]
	public Color NeutralTertiaryAlt2 { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralTertiaryAlt3")]
	public Color NeutralTertiaryAlt3 { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralTertiaryContrast")]
	public Color NeutralTertiaryContrast { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("danger")]
	public Color Danger { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("success")]
	public Color Success { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("warning")]
	public Color Warning { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("info")]
	public Color Info { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("dangerContrast")]
	public Color DangerContrast { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("successContrast")]
	public Color SuccessContrast { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("warningContrast")]
	public Color WarningContrast { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("infoContrast")]
	public Color InfoContrast { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiGood")]
	public Color KpiGood { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiBad")]
	public Color KpiBad { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiNeutral")]
	public Color KpiNeutral { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiNone")]
	public Color KpiNone { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiGoodContrast")]
	public Color KpiGoodContrast { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiBadContrast")]
	public Color KpiBadContrast { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiNeutralContrast")]
	public Color KpiNeutralContrast { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiNoneContrast")]
	public Color KpiNoneContrast { get; set; }
}
