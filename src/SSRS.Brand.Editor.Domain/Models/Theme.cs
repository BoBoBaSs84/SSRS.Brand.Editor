using System.Text.Json.Serialization;

namespace SSRS.Brand.Editor.Domain.Models;

public sealed class Theme : ITheme
{
	public Theme(List<string> dataPoints, string good, string bad, string neutral, string none, string background, string foreground, string mapBase, string panelBackground, string panelForeground, string panelAccent, string tableAccent, string altBackground, string altForeground, string altMapBase, string altPanelBackground, string altPanelForeground, string altPanelAccent, string altTableAccent)
	{
		DataPoints = dataPoints;
		Good = good;
		Bad = bad;
		Neutral = neutral;
		None = none;
		Background = background;
		Foreground = foreground;
		MapBase = mapBase;
		PanelBackground = panelBackground;
		PanelForeground = panelForeground;
		PanelAccent = panelAccent;
		TableAccent = tableAccent;
		AltBackground = altBackground;
		AltForeground = altForeground;
		AltMapBase = altMapBase;
		AltPanelBackground = altPanelBackground;
		AltPanelForeground = altPanelForeground;
		AltPanelAccent = altPanelAccent;
		AltTableAccent = altTableAccent;
	}

	public Theme(ITheme theme)
	{
		DataPoints = theme.DataPoints;
		Good = theme.Good;
		Bad = theme.Bad;
		Neutral = theme.Neutral;
		None = theme.None;
		Background = theme.Background;
		Foreground = theme.Foreground;
		MapBase = theme.MapBase;
		PanelBackground = theme.PanelBackground;
		PanelForeground = theme.PanelForeground;
		PanelAccent = theme.PanelAccent;
		TableAccent = theme.TableAccent;
		AltBackground = theme.AltBackground;
		AltForeground = theme.AltForeground;
		AltMapBase = theme.AltMapBase;
		AltPanelBackground = theme.AltPanelBackground;
		AltPanelForeground = theme.AltPanelForeground;
		AltPanelAccent = theme.AltPanelAccent;
		AltTableAccent = theme.AltTableAccent;
	}

	[JsonPropertyName("dataPoints")]
	public List<string> DataPoints { get; set; }

	[JsonPropertyName("good")]
	public string Good { get; set; }

	[JsonPropertyName("bad")]
	public string Bad { get; set; }

	[JsonPropertyName("neutral")]
	public string Neutral { get; set; }

	[JsonPropertyName("none")]
	public string None { get; set; }

	[JsonPropertyName("background")]
	public string Background { get; set; }

	[JsonPropertyName("foreground")]
	public string Foreground { get; set; }

	[JsonPropertyName("mapBase")]
	public string MapBase { get; set; }

	[JsonPropertyName("panelBackground")]
	public string PanelBackground { get; set; }

	[JsonPropertyName("panelForeground")]
	public string PanelForeground { get; set; }

	[JsonPropertyName("panelAccent")]
	public string PanelAccent { get; set; }

	[JsonPropertyName("tableAccent")]
	public string TableAccent { get; set; }

	[JsonPropertyName("altBackground")]
	public string AltBackground { get; set; }

	[JsonPropertyName("altForeground")]
	public string AltForeground { get; set; }

	[JsonPropertyName("altMapBase")]
	public string AltMapBase { get; set; }

	[JsonPropertyName("altPanelBackground")]
	public string AltPanelBackground { get; set; }

	[JsonPropertyName("altPanelForeground")]
	public string AltPanelForeground { get; set; }

	[JsonPropertyName("altPanelAccent")]
	public string AltPanelAccent { get; set; }

	[JsonPropertyName("altTableAccent")]
	public string AltTableAccent { get; set; }
}
