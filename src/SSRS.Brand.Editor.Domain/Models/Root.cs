using System.Text.Json.Serialization;


namespace SSRS.Brand.Editor.Domain.Models;

public class Root
{
	public Root()
	{
	}

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("version")]
	public string Version { get; set; } = string.Empty;

	[JsonPropertyName("interface")]
	public Interface Interface { get; set; } = new Interface();

	[JsonPropertyName("theme")]
	public Theme Theme { get; set; } = new Theme();
}
