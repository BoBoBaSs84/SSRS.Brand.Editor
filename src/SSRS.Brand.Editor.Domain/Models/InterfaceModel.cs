#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text.Json.Serialization;

using SSRS.Brand.Editor.Domain.Models.Base;

namespace SSRS.Brand.Editor.Domain.Models;
[ExcludeFromCodeCoverage(Justification = "Generated")]
public sealed class InterfaceModel : ModelBase
{
	#region fields

	private Color _primary;
	private Color _primaryAlt;
	private Color _primaryAlt2;
	private Color _primaryAlt3;
	private Color _primaryAlt4;
	private Color _primaryContrast;
	private Color _secondary;
	private Color _secondaryAlt;
	private Color _secondaryAlt2;
	private Color _secondaryAlt3;
	private Color _secondaryContrast;
	private Color _neutralPrimary;
	private Color _neutralPrimaryAlt;
	private Color _neutralPrimaryAlt2;
	private Color _neutralPrimaryAlt3;
	private Color _neutralPrimaryContrast;
	private Color _neutralSecondary;
	private Color _neutralSecondaryAlt;
	private Color _neutralSecondaryAlt2;
	private Color _neutralSecondaryAlt3;
	private Color _neutralSecondaryContrast;
	private Color _neutralTertiary;
	private Color _neutralTertiaryAlt;
	private Color _neutralTertiaryAlt2;
	private Color _neutralTertiaryAlt3;
	private Color _neutralTertiaryContrast;
	private Color _danger;
	private Color _success;
	private Color _warning;
	private Color _info;
	private Color _dangerContrast;
	private Color _successContrast;
	private Color _warningContrast;
	private Color _infoContrast;
	private Color _kpiGood;
	private Color _kpiBad;
	private Color _kpiNeutral;
	private Color _kpiNone;
	private Color _kpiGoodContrast;
	private Color _kpiBadContrast;
	private Color _kpiNeutralContrast;
	private Color _kpiNoneContrast;

	#endregion

	#region properties

	[JsonPropertyName("primary")]
	public Color Primary
	{
		get => _primary;
		set => SetProperty(ref _primary, value);
	}

	[JsonPropertyName("primaryAlt")]
	public Color PrimaryAlt
	{
		get => _primaryAlt;
		set => SetProperty(ref _primaryAlt, value);
	}

	[JsonPropertyName("primaryAlt2")]
	public Color PrimaryAlt2
	{
		get => _primaryAlt2;
		set => SetProperty(ref _primaryAlt2, value);
	}

	[JsonPropertyName("primaryAlt3")]
	public Color PrimaryAlt3
	{
		get => _primaryAlt3;
		set => SetProperty(ref _primaryAlt3, value);
	}

	[JsonPropertyName("primaryAlt4")]
	public Color PrimaryAlt4
	{
		get => _primaryAlt4;
		set => SetProperty(ref _primaryAlt4, value);
	}

	[JsonPropertyName("primaryContrast")]
	public Color PrimaryContrast
	{
		get => _primaryContrast;
		set => SetProperty(ref _primaryContrast, value);
	}

	[JsonPropertyName("secondary")]
	public Color Secondary
	{
		get => _secondary;
		set => SetProperty(ref _secondary, value);
	}

	[JsonPropertyName("secondaryAlt")]
	public Color SecondaryAlt
	{
		get => _secondaryAlt;
		set => SetProperty(ref _secondaryAlt, value);
	}

	[JsonPropertyName("secondaryAlt2")]
	public Color SecondaryAlt2
	{
		get => _secondaryAlt2;
		set => SetProperty(ref _secondaryAlt2, value);
	}

	[JsonPropertyName("secondaryAlt3")]
	public Color SecondaryAlt3
	{
		get => _secondaryAlt3;
		set => SetProperty(ref _secondaryAlt3, value);
	}

	[JsonPropertyName("secondaryContrast")]
	public Color SecondaryContrast
	{
		get => _secondaryContrast;
		set => SetProperty(ref _secondaryContrast, value);
	}

	[JsonPropertyName("neutralPrimary")]
	public Color NeutralPrimary
	{
		get => _neutralPrimary;
		set => SetProperty(ref _neutralPrimary, value);
	}

	[JsonPropertyName("neutralPrimaryAlt")]
	public Color NeutralPrimaryAlt
	{
		get => _neutralPrimaryAlt;
		set => SetProperty(ref _neutralPrimaryAlt, value);
	}

	[JsonPropertyName("neutralPrimaryAlt2")]
	public Color NeutralPrimaryAlt2
	{
		get => _neutralPrimaryAlt2;
		set => SetProperty(ref _neutralPrimaryAlt2, value);
	}

	[JsonPropertyName("neutralPrimaryAlt3")]
	public Color NeutralPrimaryAlt3
	{
		get => _neutralPrimaryAlt3;
		set => SetProperty(ref _neutralPrimaryAlt3, value);
	}

	[JsonPropertyName("neutralPrimaryContrast")]
	public Color NeutralPrimaryContrast
	{
		get => _neutralPrimaryContrast;
		set => SetProperty(ref _neutralPrimaryContrast, value);
	}

	[JsonPropertyName("neutralSecondary")]
	public Color NeutralSecondary
	{
		get => _neutralSecondary;
		set => SetProperty(ref _neutralSecondary, value);
	}

	[JsonPropertyName("neutralSecondaryAlt")]
	public Color NeutralSecondaryAlt
	{
		get => _neutralSecondaryAlt;
		set => SetProperty(ref _neutralSecondaryAlt, value);
	}

	[JsonPropertyName("neutralSecondaryAlt2")]
	public Color NeutralSecondaryAlt2
	{
		get => _neutralSecondaryAlt2;
		set => SetProperty(ref _neutralSecondaryAlt2, value);
	}

	[JsonPropertyName("neutralSecondaryAlt3")]
	public Color NeutralSecondaryAlt3
	{
		get => _neutralSecondaryAlt3;
		set => SetProperty(ref _neutralSecondaryAlt3, value);
	}

	[JsonPropertyName("neutralSecondaryContrast")]
	public Color NeutralSecondaryContrast
	{
		get => _neutralSecondaryContrast;
		set => SetProperty(ref _neutralSecondaryContrast, value);
	}

	[JsonPropertyName("neutralTertiary")]
	public Color NeutralTertiary
	{
		get => _neutralTertiary;
		set => SetProperty(ref _neutralTertiary, value);
	}

	[JsonPropertyName("neutralTertiaryAlt")]
	public Color NeutralTertiaryAlt
	{
		get => _neutralTertiaryAlt;
		set => SetProperty(ref _neutralTertiaryAlt, value);
	}

	[JsonPropertyName("neutralTertiaryAlt2")]
	public Color NeutralTertiaryAlt2
	{
		get => _neutralTertiaryAlt2;
		set => SetProperty(ref _neutralTertiaryAlt2, value);
	}

	[JsonPropertyName("neutralTertiaryAlt3")]
	public Color NeutralTertiaryAlt3
	{
		get => _neutralTertiaryAlt3;
		set => SetProperty(ref _neutralTertiaryAlt3, value);
	}

	[JsonPropertyName("neutralTertiaryContrast")]
	public Color NeutralTertiaryContrast
	{
		get => _neutralTertiaryContrast;
		set => SetProperty(ref _neutralTertiaryContrast, value);
	}

	[JsonPropertyName("danger")]
	public Color Danger
	{
		get => _danger;
		set => SetProperty(ref _danger, value);
	}

	[JsonPropertyName("success")]
	public Color Success
	{
		get => _success;
		set => SetProperty(ref _success, value);
	}

	[JsonPropertyName("warning")]
	public Color Warning
	{
		get => _warning;
		set => SetProperty(ref _warning, value);
	}

	[JsonPropertyName("info")]
	public Color Info
	{
		get => _info;
		set => SetProperty(ref _info, value);
	}

	[JsonPropertyName("dangerContrast")]
	public Color DangerContrast
	{
		get => _dangerContrast;
		set => SetProperty(ref _dangerContrast, value);
	}

	[JsonPropertyName("successContrast")]
	public Color SuccessContrast
	{
		get => _successContrast;
		set => SetProperty(ref _successContrast, value);
	}

	[JsonPropertyName("warningContrast")]
	public Color WarningContrast
	{
		get => _warningContrast;
		set => SetProperty(ref _warningContrast, value);
	}

	[JsonPropertyName("infoContrast")]
	public Color InfoContrast
	{
		get => _infoContrast;
		set => SetProperty(ref _infoContrast, value);
	}

	[JsonPropertyName("kpiGood")]
	public Color KpiGood
	{
		get => _kpiGood;
		set => SetProperty(ref _kpiGood, value);
	}

	[JsonPropertyName("kpiBad")]
	public Color KpiBad
	{
		get => _kpiBad;
		set => SetProperty(ref _kpiBad, value);
	}

	[JsonPropertyName("kpiNeutral")]
	public Color KpiNeutral
	{
		get => _kpiNeutral;
		set => SetProperty(ref _kpiNeutral, value);
	}

	[JsonPropertyName("kpiNone")]
	public Color KpiNone
	{
		get => _kpiNone;
		set => SetProperty(ref _kpiNone, value);
	}

	[JsonPropertyName("kpiGoodContrast")]
	public Color KpiGoodContrast
	{
		get => _kpiGoodContrast;
		set => SetProperty(ref _kpiGoodContrast, value);
	}

	[JsonPropertyName("kpiBadContrast")]
	public Color KpiBadContrast
	{
		get => _kpiBadContrast;
		set => SetProperty(ref _kpiBadContrast, value);
	}

	[JsonPropertyName("kpiNeutralContrast")]
	public Color KpiNeutralContrast
	{
		get => _kpiNeutralContrast;
		set => SetProperty(ref _kpiNeutralContrast, value);
	}

	[JsonPropertyName("kpiNoneContrast")]
	public Color KpiNoneContrast
	{
		get => _kpiNoneContrast;
		set => SetProperty(ref _kpiNoneContrast, value);
	}

	#endregion
}
