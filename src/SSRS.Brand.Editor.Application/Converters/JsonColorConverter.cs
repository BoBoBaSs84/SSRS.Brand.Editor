using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Media;

using BB84.Extensions;

namespace SSRS.Brand.Editor.Application.Converters;

/// <summary>
/// The json converter for the <see cref="Color"/> type.
/// </summary>
public sealed class JsonColorConverter : JsonConverter<Color>
{
	/// <inheritdoc/>
	public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string? value = reader.GetString();
		return string.IsNullOrEmpty(value) ? Colors.Transparent : ToMediaColor(value.FromRGBHexString());
	}

	/// <inheritdoc/>
	public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
		=> writer.WriteStringValue(ToDrawingColor(value).ToRGBHexString());

	private static System.Drawing.Color ToDrawingColor(Color color)
		=> System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);

	// converts a System.Drawing.Color to a System.Windows.Media.Color
	private static Color ToMediaColor(System.Drawing.Color color)
		=> Color.FromArgb(color.A, color.R, color.G, color.B);
}
