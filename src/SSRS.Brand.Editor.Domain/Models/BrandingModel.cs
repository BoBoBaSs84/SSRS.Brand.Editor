using System.Drawing;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

using BB84.Notifications;

using SSRS.Brand.Editor.Domain.Converters;

namespace SSRS.Brand.Editor.Domain.Models;

public sealed class BrandingModel : NotificationObject
{
	private ColorsModel _colors;
	private MetadataModel _metadata;

	public BrandingModel()
	{
		_colors = new();
		_metadata = new();
	}

	public ColorsModel Colors
	{
		get => _colors;
		set => SetProperty(ref _colors, value);
	}

	public MetadataModel Metadata
	{
		get => _metadata;
		set => SetProperty(ref _metadata, value);
	}
}

public class ColorsModel : NotificationObject
{
	#region fields

	private string _name;
	private string _version;
	private InterfaceModel _interface;
	private ThemeModel _theme;

	#endregion

	public ColorsModel()
	{
		_name = string.Empty;
		_version = string.Empty;
		_interface = new();
		_theme = new();
	}

	public ColorsModel(string name, string version)
	{
		_name = name;
		_version = version;
		_interface = new();
		_theme = new();
	}

	#region properties

	[JsonPropertyName("name")]
	public string Name
	{
		get => _name;
		set => SetProperty(ref _name, value);
	}

	[JsonPropertyName("version")]
	public string Version
	{
		get => _version;
		set => SetProperty(ref _version, value);
	}

	[JsonPropertyName("interface")]
	public InterfaceModel Interface
	{
		get => _interface;
		set => SetProperty(ref _interface, value);
	}

	[JsonPropertyName("theme")]
	public ThemeModel Theme
	{
		get => _theme;
		set => SetProperty(ref _theme, value);
	}

	#endregion
}

public sealed class InterfaceModel : NotificationObject
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

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("primary")]
	public Color Primary
	{
		get => _primary;
		set => SetProperty(ref _primary, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("primaryAlt")]
	public Color PrimaryAlt
	{
		get => _primaryAlt;
		set => SetProperty(ref _primaryAlt, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("primaryAlt2")]
	public Color PrimaryAlt2
	{
		get => _primaryAlt2;
		set => SetProperty(ref _primaryAlt2, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("primaryAlt3")]
	public Color PrimaryAlt3
	{
		get => _primaryAlt3;
		set => SetProperty(ref _primaryAlt3, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("primaryAlt4")]
	public Color PrimaryAlt4
	{
		get => _primaryAlt4;
		set => SetProperty(ref _primaryAlt4, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("primaryContrast")]
	public Color PrimaryContrast
	{
		get => _primaryContrast;
		set => SetProperty(ref _primaryContrast, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("secondary")]
	public Color Secondary
	{
		get => _secondary;
		set => SetProperty(ref _secondary, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("secondaryAlt")]
	public Color SecondaryAlt
	{
		get => _secondaryAlt;
		set => SetProperty(ref _secondaryAlt, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("secondaryAlt2")]
	public Color SecondaryAlt2
	{
		get => _secondaryAlt2;
		set => SetProperty(ref _secondaryAlt2, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("secondaryAlt3")]
	public Color SecondaryAlt3
	{
		get => _secondaryAlt3;
		set => SetProperty(ref _secondaryAlt3, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("secondaryContrast")]
	public Color SecondaryContrast
	{
		get => _secondaryContrast;
		set => SetProperty(ref _secondaryContrast, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralPrimary")]
	public Color NeutralPrimary
	{
		get => _neutralPrimary;
		set => SetProperty(ref _neutralPrimary, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralPrimaryAlt")]
	public Color NeutralPrimaryAlt
	{
		get => _neutralPrimaryAlt;
		set => SetProperty(ref _neutralPrimaryAlt, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralPrimaryAlt2")]
	public Color NeutralPrimaryAlt2
	{
		get => _neutralPrimaryAlt2;
		set => SetProperty(ref _neutralPrimaryAlt2, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralPrimaryAlt3")]
	public Color NeutralPrimaryAlt3
	{
		get => _neutralPrimaryAlt3;
		set => SetProperty(ref _neutralPrimaryAlt3, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralPrimaryContrast")]
	public Color NeutralPrimaryContrast
	{
		get => _neutralPrimaryContrast;
		set => SetProperty(ref _neutralPrimaryContrast, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralSecondary")]
	public Color NeutralSecondary
	{
		get => _neutralSecondary;
		set => SetProperty(ref _neutralSecondary, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralSecondaryAlt")]
	public Color NeutralSecondaryAlt
	{
		get => _neutralSecondaryAlt;
		set => SetProperty(ref _neutralSecondaryAlt, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralSecondaryAlt2")]
	public Color NeutralSecondaryAlt2
	{
		get => _neutralSecondaryAlt2;
		set => SetProperty(ref _neutralSecondaryAlt2, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralSecondaryAlt3")]
	public Color NeutralSecondaryAlt3
	{
		get => _neutralSecondaryAlt3;
		set => SetProperty(ref _neutralSecondaryAlt3, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralSecondaryContrast")]
	public Color NeutralSecondaryContrast
	{
		get => _neutralSecondaryContrast;
		set => SetProperty(ref _neutralSecondaryContrast, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralTertiary")]
	public Color NeutralTertiary
	{
		get => _neutralTertiary;
		set => SetProperty(ref _neutralTertiary, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralTertiaryAlt")]
	public Color NeutralTertiaryAlt
	{
		get => _neutralTertiaryAlt;
		set => SetProperty(ref _neutralTertiaryAlt, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralTertiaryAlt2")]
	public Color NeutralTertiaryAlt2
	{
		get => _neutralTertiaryAlt2;
		set => SetProperty(ref _neutralTertiaryAlt2, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralTertiaryAlt3")]
	public Color NeutralTertiaryAlt3
	{
		get => _neutralTertiaryAlt3;
		set => SetProperty(ref _neutralTertiaryAlt3, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutralTertiaryContrast")]
	public Color NeutralTertiaryContrast
	{
		get => _neutralTertiaryContrast;
		set => SetProperty(ref _neutralTertiaryContrast, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("danger")]
	public Color Danger
	{
		get => _danger;
		set => SetProperty(ref _danger, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("success")]
	public Color Success
	{
		get => _success;
		set => SetProperty(ref _success, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("warning")]
	public Color Warning
	{
		get => _warning;
		set => SetProperty(ref _warning, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("info")]
	public Color Info
	{
		get => _info;
		set => SetProperty(ref _info, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("dangerContrast")]
	public Color DangerContrast
	{
		get => _dangerContrast;
		set => SetProperty(ref _dangerContrast, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("successContrast")]
	public Color SuccessContrast
	{
		get => _successContrast;
		set => SetProperty(ref _successContrast, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("warningContrast")]
	public Color WarningContrast
	{
		get => _warningContrast;
		set => SetProperty(ref _warningContrast, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("infoContrast")]
	public Color InfoContrast
	{
		get => _infoContrast;
		set => SetProperty(ref _infoContrast, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiGood")]
	public Color KpiGood
	{
		get => _kpiGood;
		set => SetProperty(ref _kpiGood, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiBad")]
	public Color KpiBad
	{
		get => _kpiBad;
		set => SetProperty(ref _kpiBad, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiNeutral")]
	public Color KpiNeutral
	{
		get => _kpiNeutral;
		set => SetProperty(ref _kpiNeutral, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiNone")]
	public Color KpiNone
	{
		get => _kpiNone;
		set => SetProperty(ref _kpiNone, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiGoodContrast")]
	public Color KpiGoodContrast
	{
		get => _kpiGoodContrast;
		set => SetProperty(ref _kpiGoodContrast, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiBadContrast")]
	public Color KpiBadContrast
	{
		get => _kpiBadContrast;
		set => SetProperty(ref _kpiBadContrast, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiNeutralContrast")]
	public Color KpiNeutralContrast
	{
		get => _kpiNeutralContrast;
		set => SetProperty(ref _kpiNeutralContrast, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("kpiNoneContrast")]
	public Color KpiNoneContrast
	{
		get => _kpiNoneContrast;
		set => SetProperty(ref _kpiNoneContrast, value);
	}

	#endregion
}

public sealed class ThemeModel : NotificationObject
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
		=> DataPoints = [];

	#region properties

	[JsonPropertyName("dataPoints")]
	public List<Color> DataPoints
	{
		get => _dataPoints;
		set => SetProperty(ref _dataPoints, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("good")]
	public Color Good
	{
		get => _good;
		set => SetProperty(ref _good, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("bad")]
	public Color Bad
	{
		get => _bad;
		set => SetProperty(ref _bad, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("neutral")]
	public Color Neutral
	{
		get => _neutral;
		set => SetProperty(ref _neutral, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("none")]
	public Color None
	{
		get => _none;
		set => SetProperty(ref _none, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("background")]
	public Color Background
	{
		get => _background;
		set => SetProperty(ref _background, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("foreground")]
	public Color Foreground
	{
		get => _foreground;
		set => SetProperty(ref _foreground, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("mapBase")]
	public Color MapBase
	{
		get => _mapBase;
		set => SetProperty(ref _mapBase, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("panelBackground")]
	public Color PanelBackground
	{
		get => _panelBackground;
		set => SetProperty(ref _panelBackground, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("panelForeground")]
	public Color PanelForeground
	{
		get => _panelForeground;
		set => SetProperty(ref _panelForeground, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("panelAccent")]
	public Color PanelAccent
	{
		get => _panelAccent;
		set => SetProperty(ref _panelAccent, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("tableAccent")]
	public Color TableAccent
	{
		get => _tableAccent;
		set => SetProperty(ref _tableAccent, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altBackground")]
	public Color AltBackground
	{
		get => _altBackground;
		set => SetProperty(ref _altBackground, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altForeground")]
	public Color AltForeground
	{
		get => _altForeground;
		set => SetProperty(ref _altForeground, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altMapBase")]
	public Color AltMapBase
	{
		get => _altMapBase;
		set => SetProperty(ref _altMapBase, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altPanelBackground")]
	public Color AltPanelBackground
	{
		get => _altPanelBackground;
		set => SetProperty(ref _altPanelBackground, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altPanelForeground")]
	public Color AltPanelForeground
	{
		get => _altPanelForeground;
		set => SetProperty(ref _altPanelForeground, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altPanelAccent")]
	public Color AltPanelAccent
	{
		get => _altPanelAccent;
		set => SetProperty(ref _altPanelAccent, value);
	}

	[JsonConverter(typeof(ColorJsonConverter)), JsonPropertyName("altTableAccent")]
	public Color AltTableAccent
	{
		get => _altTableAccent;
		set => SetProperty(ref _altTableAccent, value);
	}

	#endregion
}

[XmlRoot(ElementName = "SystemResourcePackage", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
public class MetadataModel : NotificationObject
{
	#region fields

	private string _type;
	private string _version;
	private string _name;
	private List<ItemModel> _items;

	#endregion

	public MetadataModel()
	{
		_type = string.Empty;
		_version = string.Empty;
		_name = string.Empty;
		_items = [];
	}

	public MetadataModel(string type, string version, string name)
	{
		_type = type;
		_version = version;
		_name = name;
		_items = [];
	}

	#region properties

	[XmlAttribute(AttributeName = "type", Namespace = "")]
	public string Type
	{
		get => _type;
		set => SetProperty(ref _type, value);
	}

	[XmlAttribute(AttributeName = "version", Namespace = "")]
	public string Version
	{
		get => _version;
		set => SetProperty(ref _version, value);
	}

	[XmlAttribute(AttributeName = "name", Namespace = "")]
	public string Name
	{
		get => _name;
		set => SetProperty(ref _name, value);
	}

	[XmlArray(ElementName = "Contents", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
	[XmlArrayItem(ElementName = "Item", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
	public List<ItemModel> Items
	{
		get => _items;
		set => SetProperty(ref _items, value);
	}

	#endregion
}

[XmlRoot(ElementName = "Item", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
public sealed class ItemModel : NotificationObject
{
	private string _key;
	private string _path;

	public ItemModel()
	{
		_key = string.Empty;
		_path = string.Empty;
	}

	public ItemModel(string key, string path)
	{
		_key = key;
		_path = path;
	}

	[XmlAttribute(AttributeName = "key", Namespace = "")]
	public string Key
	{
		get => _key;
		set => SetProperty(ref _key, value);
	}

	[XmlAttribute(AttributeName = "path", Namespace = "")]
	public string Path
	{
		get => _path;
		set => SetProperty(ref _path, value);
	}
}
