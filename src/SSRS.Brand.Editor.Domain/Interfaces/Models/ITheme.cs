using System.Drawing;

namespace SSRS.Brand.Editor.Domain.Interfaces.Models;
public interface ITheme
{
	Color AltBackground { get; set; }
	Color AltForeground { get; set; }
	Color AltMapBase { get; set; }
	Color AltPanelAccent { get; set; }
	Color AltPanelBackground { get; set; }
	Color AltPanelForeground { get; set; }
	Color AltTableAccent { get; set; }
	Color Background { get; set; }
	Color Bad { get; set; }
	List<Color> DataPoints { get; set; }
	Color Foreground { get; set; }
	Color Good { get; set; }
	Color MapBase { get; set; }
	Color Neutral { get; set; }
	Color None { get; set; }
	Color PanelAccent { get; set; }
	Color PanelBackground { get; set; }
	Color PanelForeground { get; set; }
	Color TableAccent { get; set; }
}