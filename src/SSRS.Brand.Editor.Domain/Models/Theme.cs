using System.Drawing;
using System.Text.Json.Serialization;

using SSRS.Brand.Editor.Domain.Converters;

namespace SSRS.Brand.Editor.Domain.Models;

public sealed class Theme
{
	public Theme()
	{ }

	[JsonPropertyName("dataPoints")]
	public List<Color> DataPoints { get; set; } = new();

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("good")]
	public Color Good { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("bad")]
	public Color Bad { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutral")]
	public Color Neutral { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("none")]
	public Color None { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("background")]
	public Color Background { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("foreground")]
	public Color Foreground { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("mapBase")]
	public Color MapBase { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("panelBackground")]
	public Color PanelBackground { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("panelForeground")]
	public Color PanelForeground { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("panelAccent")]
	public Color PanelAccent { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("tableAccent")]
	public Color TableAccent { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altBackground")]
	public Color AltBackground { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altForeground")]
	public Color AltForeground { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altMapBase")]
	public Color AltMapBase { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altPanelBackground")]
	public Color AltPanelBackground { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altPanelForeground")]
	public Color AltPanelForeground { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altPanelAccent")]
	public Color AltPanelAccent { get; set; }

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altTableAccent")]
	public Color AltTableAccent { get; set; }
}
