// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Drawing;

using SSRS.Brand.Editor.Domain.Models.Base;

namespace SSRS.Brand.Editor.Domain.Models;

/// <summary>
/// The interface colors model representing the <c>interface</c> section of the <c>colors.json</c> file.
/// </summary>
/// <remarks>
/// Contains all color properties that control the SSRS web portal UI appearance.
/// </remarks>
public sealed class InterfaceColorsModel : ValidatableModelBase
{
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
	private Color _itemTypeIconColor;
	private Color _reportIconBackground;
	private Color _excelIconBackground;
	private Color _folderIconBackground;
	private Color _datasetIconBackground;
	private Color _otherIconBackground;
	private Color _primaryButton;
	private Color _primaryButtonHover;
	private Color _primaryButtonPressed;
	private Color _link;
	private Color _linkHover;
	private Color _linkVisited;
	private Color _radioButtonCheckBox;
	private Color _radioButtonCheckBoxHover;

	#region Primary

	/// <summary>
	/// The primary color for buttons and hover elements.
	/// </summary>
	public Color Primary
	{
		get => _primary;
		set => SetProperty(ref _primary, value);
	}

	/// <summary>
	/// The primary alternate color.
	/// </summary>
	public Color PrimaryAlt
	{
		get => _primaryAlt;
		set => SetProperty(ref _primaryAlt, value);
	}

	/// <summary>
	/// The primary alternate color 2.
	/// </summary>
	public Color PrimaryAlt2
	{
		get => _primaryAlt2;
		set => SetProperty(ref _primaryAlt2, value);
	}

	/// <summary>
	/// The primary alternate color 3.
	/// </summary>
	public Color PrimaryAlt3
	{
		get => _primaryAlt3;
		set => SetProperty(ref _primaryAlt3, value);
	}

	/// <summary>
	/// The primary alternate color 4.
	/// </summary>
	public Color PrimaryAlt4
	{
		get => _primaryAlt4;
		set => SetProperty(ref _primaryAlt4, value);
	}

	/// <summary>
	/// The primary contrast color.
	/// </summary>
	public Color PrimaryContrast
	{
		get => _primaryContrast;
		set => SetProperty(ref _primaryContrast, value);
	}

	#endregion

	#region Secondary

	/// <summary>
	/// The secondary color for title bar, search bar, and left hand menu.
	/// </summary>
	public Color Secondary
	{
		get => _secondary;
		set => SetProperty(ref _secondary, value);
	}

	/// <summary>
	/// The secondary alternate color.
	/// </summary>
	public Color SecondaryAlt
	{
		get => _secondaryAlt;
		set => SetProperty(ref _secondaryAlt, value);
	}

	/// <summary>
	/// The secondary alternate color 2.
	/// </summary>
	public Color SecondaryAlt2
	{
		get => _secondaryAlt2;
		set => SetProperty(ref _secondaryAlt2, value);
	}

	/// <summary>
	/// The secondary alternate color 3.
	/// </summary>
	public Color SecondaryAlt3
	{
		get => _secondaryAlt3;
		set => SetProperty(ref _secondaryAlt3, value);
	}

	/// <summary>
	/// The secondary contrast color.
	/// </summary>
	public Color SecondaryContrast
	{
		get => _secondaryContrast;
		set => SetProperty(ref _secondaryContrast, value);
	}

	#endregion

	#region Neutral Primary

	/// <summary>
	/// The neutral primary color for home and report area backgrounds.
	/// </summary>
	public Color NeutralPrimary
	{
		get => _neutralPrimary;
		set => SetProperty(ref _neutralPrimary, value);
	}

	/// <summary>
	/// The neutral primary alternate color.
	/// </summary>
	public Color NeutralPrimaryAlt
	{
		get => _neutralPrimaryAlt;
		set => SetProperty(ref _neutralPrimaryAlt, value);
	}

	/// <summary>
	/// The neutral primary alternate color 2.
	/// </summary>
	public Color NeutralPrimaryAlt2
	{
		get => _neutralPrimaryAlt2;
		set => SetProperty(ref _neutralPrimaryAlt2, value);
	}

	/// <summary>
	/// The neutral primary alternate color 3.
	/// </summary>
	public Color NeutralPrimaryAlt3
	{
		get => _neutralPrimaryAlt3;
		set => SetProperty(ref _neutralPrimaryAlt3, value);
	}

	/// <summary>
	/// The neutral primary contrast color.
	/// </summary>
	public Color NeutralPrimaryContrast
	{
		get => _neutralPrimaryContrast;
		set => SetProperty(ref _neutralPrimaryContrast, value);
	}

	#endregion

	#region Neutral Secondary

	/// <summary>
	/// The neutral secondary color for text box and folder options backgrounds.
	/// </summary>
	public Color NeutralSecondary
	{
		get => _neutralSecondary;
		set => SetProperty(ref _neutralSecondary, value);
	}

	/// <summary>
	/// The neutral secondary alternate color.
	/// </summary>
	public Color NeutralSecondaryAlt
	{
		get => _neutralSecondaryAlt;
		set => SetProperty(ref _neutralSecondaryAlt, value);
	}

	/// <summary>
	/// The neutral secondary alternate color 2.
	/// </summary>
	public Color NeutralSecondaryAlt2
	{
		get => _neutralSecondaryAlt2;
		set => SetProperty(ref _neutralSecondaryAlt2, value);
	}

	/// <summary>
	/// The neutral secondary alternate color 3.
	/// </summary>
	public Color NeutralSecondaryAlt3
	{
		get => _neutralSecondaryAlt3;
		set => SetProperty(ref _neutralSecondaryAlt3, value);
	}

	/// <summary>
	/// The neutral secondary contrast color.
	/// </summary>
	public Color NeutralSecondaryContrast
	{
		get => _neutralSecondaryContrast;
		set => SetProperty(ref _neutralSecondaryContrast, value);
	}

	#endregion

	#region Neutral Tertiary

	/// <summary>
	/// The neutral tertiary color for site settings backgrounds.
	/// </summary>
	public Color NeutralTertiary
	{
		get => _neutralTertiary;
		set => SetProperty(ref _neutralTertiary, value);
	}

	/// <summary>
	/// The neutral tertiary alternate color.
	/// </summary>
	public Color NeutralTertiaryAlt
	{
		get => _neutralTertiaryAlt;
		set => SetProperty(ref _neutralTertiaryAlt, value);
	}

	/// <summary>
	/// The neutral tertiary alternate color 2.
	/// </summary>
	public Color NeutralTertiaryAlt2
	{
		get => _neutralTertiaryAlt2;
		set => SetProperty(ref _neutralTertiaryAlt2, value);
	}

	/// <summary>
	/// The neutral tertiary alternate color 3.
	/// </summary>
	public Color NeutralTertiaryAlt3
	{
		get => _neutralTertiaryAlt3;
		set => SetProperty(ref _neutralTertiaryAlt3, value);
	}

	/// <summary>
	/// The neutral tertiary contrast color.
	/// </summary>
	public Color NeutralTertiaryContrast
	{
		get => _neutralTertiaryContrast;
		set => SetProperty(ref _neutralTertiaryContrast, value);
	}

	#endregion

	#region Status Messages

	/// <summary>
	/// The danger status color.
	/// </summary>
	public Color Danger
	{
		get => _danger;
		set => SetProperty(ref _danger, value);
	}

	/// <summary>
	/// The success status color.
	/// </summary>
	public Color Success
	{
		get => _success;
		set => SetProperty(ref _success, value);
	}

	/// <summary>
	/// The warning status color.
	/// </summary>
	public Color Warning
	{
		get => _warning;
		set => SetProperty(ref _warning, value);
	}

	/// <summary>
	/// The info status color.
	/// </summary>
	public Color Info
	{
		get => _info;
		set => SetProperty(ref _info, value);
	}

	/// <summary>
	/// The danger contrast color.
	/// </summary>
	public Color DangerContrast
	{
		get => _dangerContrast;
		set => SetProperty(ref _dangerContrast, value);
	}

	/// <summary>
	/// The success contrast color.
	/// </summary>
	public Color SuccessContrast
	{
		get => _successContrast;
		set => SetProperty(ref _successContrast, value);
	}

	/// <summary>
	/// The warning contrast color.
	/// </summary>
	public Color WarningContrast
	{
		get => _warningContrast;
		set => SetProperty(ref _warningContrast, value);
	}

	/// <summary>
	/// The info contrast color.
	/// </summary>
	public Color InfoContrast
	{
		get => _infoContrast;
		set => SetProperty(ref _infoContrast, value);
	}

	#endregion

	#region KPI

	/// <summary>
	/// The KPI good status color.
	/// </summary>
	public Color KpiGood
	{
		get => _kpiGood;
		set => SetProperty(ref _kpiGood, value);
	}

	/// <summary>
	/// The KPI bad status color.
	/// </summary>
	public Color KpiBad
	{
		get => _kpiBad;
		set => SetProperty(ref _kpiBad, value);
	}

	/// <summary>
	/// The KPI neutral status color.
	/// </summary>
	public Color KpiNeutral
	{
		get => _kpiNeutral;
		set => SetProperty(ref _kpiNeutral, value);
	}

	/// <summary>
	/// The KPI none status color.
	/// </summary>
	public Color KpiNone
	{
		get => _kpiNone;
		set => SetProperty(ref _kpiNone, value);
	}

	/// <summary>
	/// The KPI good contrast color.
	/// </summary>
	public Color KpiGoodContrast
	{
		get => _kpiGoodContrast;
		set => SetProperty(ref _kpiGoodContrast, value);
	}

	/// <summary>
	/// The KPI bad contrast color.
	/// </summary>
	public Color KpiBadContrast
	{
		get => _kpiBadContrast;
		set => SetProperty(ref _kpiBadContrast, value);
	}

	/// <summary>
	/// The KPI neutral contrast color.
	/// </summary>
	public Color KpiNeutralContrast
	{
		get => _kpiNeutralContrast;
		set => SetProperty(ref _kpiNeutralContrast, value);
	}

	/// <summary>
	/// The KPI none contrast color.
	/// </summary>
	public Color KpiNoneContrast
	{
		get => _kpiNoneContrast;
		set => SetProperty(ref _kpiNoneContrast, value);
	}

	#endregion

	#region Icons

	/// <summary>
	/// The item type icon foreground color.
	/// </summary>
	public Color ItemTypeIconColor
	{
		get => _itemTypeIconColor;
		set => SetProperty(ref _itemTypeIconColor, value);
	}

	/// <summary>
	/// The report icon background color.
	/// </summary>
	public Color ReportIconBackground
	{
		get => _reportIconBackground;
		set => SetProperty(ref _reportIconBackground, value);
	}

	/// <summary>
	/// The Excel icon background color.
	/// </summary>
	public Color ExcelIconBackground
	{
		get => _excelIconBackground;
		set => SetProperty(ref _excelIconBackground, value);
	}

	/// <summary>
	/// The folder icon background color.
	/// </summary>
	public Color FolderIconBackground
	{
		get => _folderIconBackground;
		set => SetProperty(ref _folderIconBackground, value);
	}

	/// <summary>
	/// The dataset icon background color.
	/// </summary>
	public Color DatasetIconBackground
	{
		get => _datasetIconBackground;
		set => SetProperty(ref _datasetIconBackground, value);
	}

	/// <summary>
	/// The other icon background color.
	/// </summary>
	public Color OtherIconBackground
	{
		get => _otherIconBackground;
		set => SetProperty(ref _otherIconBackground, value);
	}

	#endregion

	#region Buttons

	/// <summary>
	/// The primary button color.
	/// </summary>
	public Color PrimaryButton
	{
		get => _primaryButton;
		set => SetProperty(ref _primaryButton, value);
	}

	/// <summary>
	/// The primary button hover color.
	/// </summary>
	public Color PrimaryButtonHover
	{
		get => _primaryButtonHover;
		set => SetProperty(ref _primaryButtonHover, value);
	}

	/// <summary>
	/// The primary button pressed color.
	/// </summary>
	public Color PrimaryButtonPressed
	{
		get => _primaryButtonPressed;
		set => SetProperty(ref _primaryButtonPressed, value);
	}

	#endregion

	#region Links

	/// <summary>
	/// The link color.
	/// </summary>
	public Color Link
	{
		get => _link;
		set => SetProperty(ref _link, value);
	}

	/// <summary>
	/// The link hover color.
	/// </summary>
	public Color LinkHover
	{
		get => _linkHover;
		set => SetProperty(ref _linkHover, value);
	}

	/// <summary>
	/// The link visited color.
	/// </summary>
	public Color LinkVisited
	{
		get => _linkVisited;
		set => SetProperty(ref _linkVisited, value);
	}

	#endregion

	#region Controls

	/// <summary>
	/// The radio button and check box color.
	/// </summary>
	public Color RadioButtonCheckBox
	{
		get => _radioButtonCheckBox;
		set => SetProperty(ref _radioButtonCheckBox, value);
	}

	/// <summary>
	/// The radio button and check box hover color.
	/// </summary>
	public Color RadioButtonCheckBoxHover
	{
		get => _radioButtonCheckBoxHover;
		set => SetProperty(ref _radioButtonCheckBoxHover, value);
	}

	#endregion
}
