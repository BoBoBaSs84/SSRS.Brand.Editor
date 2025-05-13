#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text.Json.Serialization;

using SSRS.Brand.Editor.Domain.Models.Base;

namespace SSRS.Brand.Editor.Domain.Models;

[ExcludeFromCodeCoverage(Justification = "Generated")]
public sealed class ThemeModel : ModelBase
{
	#region fields

	private List<Color> _dataPoints;
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

	#endregion

	public ThemeModel()
		=> _dataPoints = [];

	#region properties

	[JsonPropertyName("dataPoints")]
	public List<Color> DataPoints
	{
		get => _dataPoints;
		set => SetProperty(ref _dataPoints, value);
	}

	[JsonPropertyName("good")]
	public Color Good
	{
		get => _good;
		set => SetProperty(ref _good, value);
	}

	[JsonPropertyName("bad")]
	public Color Bad
	{
		get => _bad;
		set => SetProperty(ref _bad, value);
	}

	[JsonPropertyName("neutral")]
	public Color Neutral
	{
		get => _neutral;
		set => SetProperty(ref _neutral, value);
	}

	[JsonPropertyName("none")]
	public Color None
	{
		get => _none;
		set => SetProperty(ref _none, value);
	}

	[JsonPropertyName("background")]
	public Color Background
	{
		get => _background;
		set => SetProperty(ref _background, value);
	}

	[JsonPropertyName("foreground")]
	public Color Foreground
	{
		get => _foreground;
		set => SetProperty(ref _foreground, value);
	}

	[JsonPropertyName("mapBase")]
	public Color MapBase
	{
		get => _mapBase;
		set => SetProperty(ref _mapBase, value);
	}

	[JsonPropertyName("panelBackground")]
	public Color PanelBackground
	{
		get => _panelBackground;
		set => SetProperty(ref _panelBackground, value);
	}

	[JsonPropertyName("panelForeground")]
	public Color PanelForeground
	{
		get => _panelForeground;
		set => SetProperty(ref _panelForeground, value);
	}

	[JsonPropertyName("panelAccent")]
	public Color PanelAccent
	{
		get => _panelAccent;
		set => SetProperty(ref _panelAccent, value);
	}

	[JsonPropertyName("tableAccent")]
	public Color TableAccent
	{
		get => _tableAccent;
		set => SetProperty(ref _tableAccent, value);
	}

	[JsonPropertyName("altBackground")]
	public Color AltBackground
	{
		get => _altBackground;
		set => SetProperty(ref _altBackground, value);
	}

	[JsonPropertyName("altForeground")]
	public Color AltForeground
	{
		get => _altForeground;
		set => SetProperty(ref _altForeground, value);
	}

	[JsonPropertyName("altMapBase")]
	public Color AltMapBase
	{
		get => _altMapBase;
		set => SetProperty(ref _altMapBase, value);
	}

	[JsonPropertyName("altPanelBackground")]
	public Color AltPanelBackground
	{
		get => _altPanelBackground;
		set => SetProperty(ref _altPanelBackground, value);
	}

	[JsonPropertyName("altPanelForeground")]
	public Color AltPanelForeground
	{
		get => _altPanelForeground;
		set => SetProperty(ref _altPanelForeground, value);
	}

	[JsonPropertyName("altPanelAccent")]
	public Color AltPanelAccent
	{
		get => _altPanelAccent;
		set => SetProperty(ref _altPanelAccent, value);
	}

	[JsonPropertyName("altTableAccent")]
	public Color AltTableAccent
	{
		get => _altTableAccent;
		set => SetProperty(ref _altTableAccent, value);
	}

	#endregion
}
