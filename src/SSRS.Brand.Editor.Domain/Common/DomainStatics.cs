using System.Text.Json;

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
			JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
			{
				Converters = { new ColorJsonConverter() }
			};

			return options;
		}
	}
}
