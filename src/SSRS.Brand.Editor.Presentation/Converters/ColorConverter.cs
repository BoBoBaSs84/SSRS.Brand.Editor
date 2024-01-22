using System.Globalization;
using System.Windows.Data;

using DColor = System.Drawing.Color;
using MColor = System.Windows.Media.Color;

namespace SSRS.Brand.Editor.Presentation.Converters;

/// <summary>
/// The color converter class.
/// </summary>
[ValueConversion(typeof(DColor), typeof(MColor))]
internal sealed class ColorConverter : IValueConverter
{
	/// <inheritdoc/>
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		DColor color = (DColor)value;
		return MColor.FromArgb(color.A, color.R, color.G, color.B);
	}

	/// <inheritdoc/>
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		MColor color = (MColor)value;
		return DColor.FromArgb(color.A, color.R, color.G, color.B);
	}
}
