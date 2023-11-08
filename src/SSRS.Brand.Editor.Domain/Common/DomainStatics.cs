using System.Text.Json;
using System.Text.Json.Serialization;

using SSRS.Brand.Editor.Domain.Converters;

namespace SSRS.Brand.Editor.Domain.Common;

/// <summary>
/// The domain statics class.
/// </summary>
public static class DomainStatics
{
	/// <summary>
	/// The standard JSON serializer options.
	/// </summary>
	public static JsonSerializerOptions SerializerOptions
	{
		get
		{
			JsonSerializerOptions options = new()
			{
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};

			options.Converters.Add(new ColorJsonConverter());

			return options;
		}
	}
}
