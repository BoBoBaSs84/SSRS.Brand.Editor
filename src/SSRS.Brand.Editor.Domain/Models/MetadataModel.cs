using System.ComponentModel.DataAnnotations;

using SSRS.Brand.Editor.Domain.Models.Base;

namespace SSRS.Brand.Editor.Domain.Models;

/// <summary>
/// The metadata model representing the <c>metadata.xml</c> brand package manifest.
/// </summary>
public sealed class MetadataModel : ValidatableModelBase
{
	/// <summary>
	/// The XML namespace for the SSRS brand package metadata.
	/// </summary>
	public const string XmlNamespace = "http://schemas.microsoft.com/sqlserver/reporting/2016/01/systemresourcepackagemetadata";

	/// <summary>
	/// The fixed package type.
	/// </summary>
	public const string PackageType = "UniversalBrand";

	/// <summary>
	/// The default package version.
	/// </summary>
	public const string DefaultVersion = "2.0.2";

	/// <summary>
	/// The default colors file path.
	/// </summary>
	public const string ColorsPath = "colors.json";

	/// <summary>
	/// The default logo file path.
	/// </summary>
	public const string LogoPath = "logo.png";

	private string _name = string.Empty;
	private string _version = DefaultVersion;
	private bool _hasLogo;

	/// <summary>
	/// The display name of the brand package.
	/// </summary>
	[Required(ErrorMessage = "Brand name must not be empty.")]
	[MinLength(1, ErrorMessage = "Brand name must not be empty.")]
	public string Name
	{
		get => _name;
		set => SetPropertyAndValidate(ref _name, value);
	}

	/// <summary>
	/// The package format version.
	/// </summary>
	public string Version
	{
		get => _version;
		set => SetProperty(ref _version, value);
	}

	/// <summary>
	/// Indicates whether the brand package includes a logo.
	/// </summary>
	public bool HasLogo
	{
		get => _hasLogo;
		set => SetProperty(ref _hasLogo, value);
	}
}
