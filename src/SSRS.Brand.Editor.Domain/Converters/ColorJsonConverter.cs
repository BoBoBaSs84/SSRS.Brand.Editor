using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

using BB84.Extensions;

namespace SSRS.Brand.Editor.Domain.Converters;

/// <summary>
/// The json converter for the <see cref="Color"/> type.
/// </summary>
public sealed class ColorJsonConverter : JsonConverter<Color>
{
	/// <inheritdoc/>
	public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string? value = reader.GetString();
		return value is null ? Color.White : value.FromRGBHexString();
	}

	/// <inheritdoc/>
	public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
		=> writer.WriteStringValue(value.ToRGBHexString());
}
