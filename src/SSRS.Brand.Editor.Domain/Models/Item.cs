using System.Xml.Serialization;

using SSRS.Brand.Editor.Domain.Interfaces.Models;

namespace SSRS.Brand.Editor.Domain.Models;

[XmlRoot(ElementName = "Item", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
public sealed class Item : IItem
{
	public Item()
	{ }

	public Item(IItem item)
	{
		Key = item.Key;
		Path = item.Path;
	}

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
