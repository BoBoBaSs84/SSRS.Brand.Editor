namespace SSRS.Brand.Editor.Domain.Models;

public interface ITheme
{
	string AltBackground { get; set; }
	string AltForeground { get; set; }
	string AltMapBase { get; set; }
	string AltPanelAccent { get; set; }
	string AltPanelBackground { get; set; }
	string AltPanelForeground { get; set; }
	string AltTableAccent { get; set; }
	string Background { get; set; }
	string Bad { get; set; }
	List<string> DataPoints { get; set; }
	string Foreground { get; set; }
	string Good { get; set; }
	string MapBase { get; set; }
	string Neutral { get; set; }
	string None { get; set; }
	string PanelAccent { get; set; }
	string PanelBackground { get; set; }
	string PanelForeground { get; set; }
	string TableAccent { get; set; }
}
