using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace SSRS.Brand.Editor.Presentation.Controls;

/// <summary>
/// A clickable color swatch that opens a <see cref="ColorPickerControl"/> popup for editing.
/// </summary>
public partial class ColorSwatchControl : UserControl
{
	/// <summary>
	/// Identifies the <see cref="Color"/> dependency property.
	/// </summary>
	public static readonly DependencyProperty ColorProperty =
		DependencyProperty.Register(
			nameof(Color),
			typeof(Color),
			typeof(ColorSwatchControl),
			new FrameworkPropertyMetadata(
				Color.Empty,
				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	/// <summary>
	/// Identifies the <see cref="Label"/> dependency property.
	/// </summary>
	public static readonly DependencyProperty LabelProperty =
		DependencyProperty.Register(
			nameof(Label),
			typeof(string),
			typeof(ColorSwatchControl),
			new PropertyMetadata(string.Empty));

	/// <summary>
	/// Gets or sets the color value.
	/// </summary>
	public Color Color
	{
		get => (Color)GetValue(ColorProperty);
		set => SetValue(ColorProperty, value);
	}

	/// <summary>
	/// Gets or sets the display label for the swatch.
	/// </summary>
	public string Label
	{
		get => (string)GetValue(LabelProperty);
		set => SetValue(LabelProperty, value);
	}

	/// <summary>
	/// Initializes an instance of the <see cref="ColorSwatchControl"/> class.
	/// </summary>
	public ColorSwatchControl()
		=> InitializeComponent();

	private void Picker_ColorApplied(object sender, RoutedEventArgs e)
		=> ColorPickerPopup.IsOpen = false;
}
