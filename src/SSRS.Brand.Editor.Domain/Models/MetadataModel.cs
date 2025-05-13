#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

using SSRS.Brand.Editor.Domain.Models.Base;

namespace SSRS.Brand.Editor.Domain.Models;

[ExcludeFromCodeCoverage(Justification = "Generated")]
[XmlRoot(ElementName = "SystemResourcePackage", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
public class MetadataModel : ModelBase
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
