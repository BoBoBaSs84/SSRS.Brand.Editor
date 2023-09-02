using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SSRS.Brand.Editor.Domain.Converters;

/// <summary>
/// The color json converter class.
/// </summary>
/// <remarks>
/// Derives from the <see cref="JsonConverter{T}"/> class.
/// </remarks>
public sealed class ColorJsonConverter : JsonConverter<Color>
{
	/// <inheritdoc/>
	public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string? value = reader.GetString();
		return value is null ? Color.White : GetColor(value);
	}

	/// <inheritdoc/>
	public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
		=> writer.WriteStringValue($"#{value.R:X2}{value.G:X2}{value.B:X2}");

	private static Color GetColor(string value)
	{
		Color color = Color.Empty;

		if (value[0].Equals('#') && ((value.Length == 7) || (value.Length == 4)))
		{
			if (value.Length == 7)
			{
				color = Color.FromArgb(
					Convert.ToInt32(value.Substring(1, 2), 16),
					Convert.ToInt32(value.Substring(3, 2), 16),
					Convert.ToInt32(value.Substring(5, 2), 16)
					);
			}
			else
			{
				string r = char.ToString(value[1]);
				string g = char.ToString(value[2]);
				string b = char.ToString(value[3]);

				color = Color.FromArgb(
					Convert.ToInt32(r + r, 16),
					Convert.ToInt32(g + g, 16),
					Convert.ToInt32(b + b, 16)
					);
			}
		}

		return color;
	}
}
