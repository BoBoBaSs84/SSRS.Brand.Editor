using System.Xml.Serialization;

namespace SSRS.Brand.Editor.Domain.Models;

[XmlRoot(ElementName = "Item", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
public sealed class Item
{
	public Item()
	{ }

	public Item(string key, string path)
	{
		Key = key;
		Path = path;
	}

	[XmlAttribute(AttributeName = "key", Namespace = "")]
	public string Key { get; set; }

	[XmlAttribute(AttributeName = "path", Namespace = "")]
	public string Path { get; set; }
}
