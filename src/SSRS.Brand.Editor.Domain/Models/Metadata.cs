using System.Xml.Serialization;

namespace SSRS.Brand.Editor.Domain.Models;

[XmlRoot(ElementName = "SystemResourcePackage", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
public class Metadata
{
	public Metadata()
	{
		Type = string.Empty;
		Version = string.Empty;
		Name = string.Empty;
		Contents = new();
	}

	[XmlAttribute(AttributeName = "type", Namespace = "")]
	public string Type { get; set; }

	[XmlAttribute(AttributeName = "version", Namespace = "")]
	public string Version { get; set; }

	[XmlAttribute(AttributeName = "name", Namespace = "")]
	public string Name { get; set; }

	[XmlElement(ElementName = "Contents", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
	public Contents Contents { get; set; }
}

[XmlRoot(ElementName = "Contents", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
public sealed class Contents
{
	public Contents()
	{
		Item = new();
	}

	[XmlElement(ElementName = "Item", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
	public List<Item> Item { get; set; }
}

[XmlRoot(ElementName = "Item", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
public sealed class Item
{
	public Item()
	{
		Key = string.Empty;
		Path = string.Empty;
	}

	[XmlAttribute(AttributeName = "key", Namespace = "")]
	public string Key { get; set; }

	[XmlAttribute(AttributeName = "path", Namespace = "")]
	public string Path { get; set; }
}
