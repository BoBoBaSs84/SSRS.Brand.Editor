#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

using SSRS.Brand.Editor.Domain.Models.Base;

namespace SSRS.Brand.Editor.Domain.Models;

[ExcludeFromCodeCoverage(Justification = "Generated")]
public class ColorsModel : ModelBase
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
