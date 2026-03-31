// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Collections.ObjectModel;
using System.Drawing;

using SSRS.Brand.Editor.Domain.Models.Base;

namespace SSRS.Brand.Editor.Domain.Models;

/// <summary>
/// The theme colors model representing the <c>theme</c> section of the <c>colors.json</c> file.
/// </summary>
/// <remarks>
/// Contains color properties specific to mobile reports and chart theming.
/// </remarks>
public sealed class ThemeColorsModel : ValidatableModelBase
{
	private Color _good;
	private Color _bad;
	private Color _neutral;
	private Color _none;
	private Color _background;
	private Color _foreground;
	private Color _mapBase;
	private Color _panelBackground;
	private Color _panelForeground;
	private Color _panelAccent;
	private Color _tableAccent;
	private Color _altBackground;
	private Color _altForeground;
	private Color _altMapBase;
	private Color _altPanelBackground;
	private Color _altPanelForeground;
	private Color _altPanelAccent;
	private Color _altTableAccent;

	/// <summary>
	/// Initializes a new instance of the <see cref="ThemeColorsModel"/> class.
	/// </summary>
	public ThemeColorsModel()
		=> DataPoints = [];

	#region Data Points

	/// <summary>
	/// The collection of data point colors used in charts and visualizations.
	/// </summary>
	public ObservableCollection<Color> DataPoints { get; }

	#endregion

	#region Status

	/// <summary>
	/// The good status indicator color.
	/// </summary>
	public Color Good
	{
		get => _good;
		set => SetProperty(ref _good, value);
	}

	/// <summary>
	/// The bad status indicator color.
	/// </summary>
	public Color Bad
	{
		get => _bad;
		set => SetProperty(ref _bad, value);
	}

	/// <summary>
	/// The neutral status indicator color.
	/// </summary>
	public Color Neutral
	{
		get => _neutral;
		set => SetProperty(ref _neutral, value);
	}

	/// <summary>
	/// The none status indicator color.
	/// </summary>
	public Color None
	{
		get => _none;
		set => SetProperty(ref _none, value);
	}

	#endregion

	#region Standard

	/// <summary>
	/// The overall background color.
	/// </summary>
	public Color Background
	{
		get => _background;
		set => SetProperty(ref _background, value);
	}

	/// <summary>
	/// The overall foreground color.
	/// </summary>
	public Color Foreground
	{
		get => _foreground;
		set => SetProperty(ref _foreground, value);
	}

	/// <summary>
	/// The base color for maps.
	/// </summary>
	public Color MapBase
	{
		get => _mapBase;
		set => SetProperty(ref _mapBase, value);
	}

	/// <summary>
	/// The panel background color.
	/// </summary>
	public Color PanelBackground
	{
		get => _panelBackground;
		set => SetProperty(ref _panelBackground, value);
	}

	/// <summary>
	/// The panel foreground color.
	/// </summary>
	public Color PanelForeground
	{
		get => _panelForeground;
		set => SetProperty(ref _panelForeground, value);
	}

	/// <summary>
	/// The panel accent color.
	/// </summary>
	public Color PanelAccent
	{
		get => _panelAccent;
		set => SetProperty(ref _panelAccent, value);
	}

	/// <summary>
	/// The table accent color.
	/// </summary>
	public Color TableAccent
	{
		get => _tableAccent;
		set => SetProperty(ref _tableAccent, value);
	}

	#endregion

	#region Alt

	/// <summary>
	/// The alternate background color.
	/// </summary>
	public Color AltBackground
	{
		get => _altBackground;
		set => SetProperty(ref _altBackground, value);
	}

	/// <summary>
	/// The alternate foreground color.
	/// </summary>
	public Color AltForeground
	{
		get => _altForeground;
		set => SetProperty(ref _altForeground, value);
	}

	/// <summary>
	/// The alternate base color for maps.
	/// </summary>
	public Color AltMapBase
	{
		get => _altMapBase;
		set => SetProperty(ref _altMapBase, value);
	}

	/// <summary>
	/// The alternate panel background color.
	/// </summary>
	public Color AltPanelBackground
	{
		get => _altPanelBackground;
		set => SetProperty(ref _altPanelBackground, value);
	}

	/// <summary>
	/// The alternate panel foreground color.
	/// </summary>
	public Color AltPanelForeground
	{
		get => _altPanelForeground;
		set => SetProperty(ref _altPanelForeground, value);
	}

	/// <summary>
	/// The alternate panel accent color.
	/// </summary>
	public Color AltPanelAccent
	{
		get => _altPanelAccent;
		set => SetProperty(ref _altPanelAccent, value);
	}

	/// <summary>
	/// The alternate table accent color.
	/// </summary>
	public Color AltTableAccent
	{
		get => _altTableAccent;
		set => SetProperty(ref _altTableAccent, value);
	}

	#endregion
}
