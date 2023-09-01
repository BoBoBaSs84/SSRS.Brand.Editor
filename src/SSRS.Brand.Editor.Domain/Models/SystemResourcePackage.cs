using System.Xml.Serialization;

namespace SSRS.Brand.Editor.Domain.Models;

[XmlRoot(ElementName = "SystemResourcePackage", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
public class SystemResourcePackage
{
	public SystemResourcePackage()
	{ }

	[XmlElement(ElementName = "Contents", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
	public Contents Contents { get; set; } = new Contents();

	[XmlAttribute(AttributeName = "type", Namespace = "")]
	public string Type { get; set; }

	[XmlAttribute(AttributeName = "version", Namespace = "")]
	public string Version { get; set; }

	[XmlAttribute(AttributeName = "name", Namespace = "")]
	public string Name { get; set; }
}
