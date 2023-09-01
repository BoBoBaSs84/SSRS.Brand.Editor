using System.Xml.Serialization;

namespace SSRS.Brand.Editor.Domain.Models;

[XmlRoot(ElementName = "Contents", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
public sealed class Contents
{
	public Contents()
	{ }

	public Contents(List<Item> item)
	{
		Item = item;
	}

	[XmlElement(ElementName = "Item", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
	public List<Item> Item { get; set; }
}
