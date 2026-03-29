using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SSRS.Brand.Editor.Presentation.Converters;

/// <summary>
/// Converts a <see cref="bool"/> to a <see cref="Visibility"/> value.
/// </summary>
[ValueConversion(typeof(bool), typeof(Visibility))]
public sealed class BoolToVisibilityConverter : IValueConverter
{
	/// <inheritdoc/>
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		=> value is true ? Visibility.Visible : Visibility.Collapsed;

	/// <inheritdoc/>
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		=> value is Visibility.Visible;
}
