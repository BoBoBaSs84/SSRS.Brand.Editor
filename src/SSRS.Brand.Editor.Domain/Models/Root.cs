using System.Text.Json.Serialization;

namespace SSRS.Brand.Editor.Domain.Models;

public class Root : IRoot
{
	public Root(string name, string version, Interface @interface, Theme theme)
	{
		Name = name;
		Version = version;
		Interface = @interface;
		Theme = theme;
	}

	public Root(IRoot root)
	{
		Name = root.Name;
		Version = root.Version;
		Interface = root.Interface;
		Theme = root.Theme;
	}

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("version")]
	public string Version { get; set; }

	[JsonPropertyName("interface")]
	public Interface Interface { get; set; }

	[JsonPropertyName("theme")]
	public Theme Theme { get; set; }
}
