// Copyright: 2025 Robert Peter Meyer
// License: MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SSRS.Brand.Editor.Presentation.Converters;

/// <summary>
/// Converts an integer index to <see cref="Visibility"/>.
/// Returns <see cref="Visibility.Visible"/> when the index is non-negative,
/// otherwise <see cref="Visibility.Collapsed"/>.
/// </summary>
[ValueConversion(typeof(int), typeof(Visibility))]
public sealed class IndexToVisibilityConverter : IValueConverter
{
	/// <inheritdoc/>
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		=> value is int index && index >= 0 ? Visibility.Visible : Visibility.Collapsed;

	/// <inheritdoc/>
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		=> throw new NotSupportedException();
}
