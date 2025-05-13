#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

using SSRS.Brand.Editor.Domain.Models.Base;

namespace SSRS.Brand.Editor.Domain.Models;

[ExcludeFromCodeCoverage(Justification = "Generated")]
[XmlRoot(ElementName = "Item", Namespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata")]
public sealed class ItemModel : ModelBase
{
	private string _key;
	private string _path;

	public ItemModel()
	{
		_key = string.Empty;
		_path = string.Empty;
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
