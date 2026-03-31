using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

using DrawingColor = System.Drawing.Color;

namespace SSRS.Brand.Editor.Presentation.Converters;

/// <summary>
/// Converts a <see cref="System.Drawing.Color"/> to a <see cref="SolidColorBrush"/>.
/// </summary>
[ValueConversion(typeof(DrawingColor), typeof(SolidColorBrush))]
public sealed class DrawingColorToBrushConverter : IValueConverter
{
	/// <inheritdoc/>
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return value is DrawingColor color
			? new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B))
			: Brushes.Transparent;
	}

	/// <inheritdoc/>
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return value is SolidColorBrush brush
			? DrawingColor.FromArgb(brush.Color.A, brush.Color.R, brush.Color.G, brush.Color.B)
			: DrawingColor.Transparent;
	}
}
