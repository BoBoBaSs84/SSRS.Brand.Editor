using System.Xml.Serialization;

using SSRS.Brand.Editor.Domain.Interfaces.Models;

namespace SSRS.Brand.Editor.Domain.Models;

[XmlRoot(ElementName = "SystemResourcePackage", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
public class SystemResourcePackage : ISystemResourcePackage
{
	public SystemResourcePackage()
	{ }

	public SystemResourcePackage(ISystemResourcePackage systemResourcePackage)
	{
		Contents = systemResourcePackage.Contents;
		Type = systemResourcePackage.Type;
		Version = systemResourcePackage.Version;
		Name = systemResourcePackage.Name;
	}

	public SystemResourcePackage(Contents contents, string type, string version, string name)
	{
		Contents = contents;
		Type = type;
		Version = version;
		Name = name;
	}

	[XmlElement(ElementName = "Contents", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
	public Contents Contents { get; set; }

	[XmlAttribute(AttributeName = "type", Namespace = "")]
	public string Type { get; set; }

	[XmlAttribute(AttributeName = "version", Namespace = "")]
	public string Version { get; set; }

	[XmlAttribute(AttributeName = "name", Namespace = "")]
	public string Name { get; set; }
}
