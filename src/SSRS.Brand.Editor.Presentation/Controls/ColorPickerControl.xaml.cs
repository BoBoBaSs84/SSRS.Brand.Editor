using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SSRS.Brand.Editor.Presentation.Controls;

/// <summary>
/// A lightweight color picker control with no external dependencies.
/// Exposes a <see cref="SelectedColor"/> dependency property of type
/// <see cref="System.Drawing.Color"/> for binding to model properties.
/// </summary>
public partial class ColorPickerControl : UserControl
{
	private bool _isUpdating;
	private bool _isDraggingCanvas;

	/// <summary>
	/// Identifies the <see cref="SelectedColor"/> dependency property.
	/// </summary>
	public static readonly DependencyProperty SelectedColorProperty =
		DependencyProperty.Register(
			nameof(SelectedColor),
			typeof(System.Drawing.Color),
			typeof(ColorPickerControl),
			new FrameworkPropertyMetadata(
				System.Drawing.Color.FromArgb(255, 0, 114, 198),
				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
				OnSelectedColorChanged));

	/// <summary>
	/// Gets or sets the selected color as a <see cref="System.Drawing.Color"/>.
	/// </summary>
	public System.Drawing.Color SelectedColor
	{
		get => (System.Drawing.Color)GetValue(SelectedColorProperty);
		set => SetValue(SelectedColorProperty, value);
	}

	/// <summary>
	/// Initializes an instance of the <see cref="ColorPickerControl"/> class.
	/// </summary>
	public ColorPickerControl()
	{
		InitializeComponent();
		Loaded += OnLoaded;
	}

	private void OnLoaded(object sender, RoutedEventArgs e)
		=> SyncFromSelectedColor(SelectedColor);

	private static void OnSelectedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ColorPickerControl picker && !picker._isUpdating)
			picker.SyncFromSelectedColor((System.Drawing.Color)e.NewValue);
	}

	// -------------------------------------------------------------------------
	// Hue / Saturation-Brightness canvas
	// -------------------------------------------------------------------------

	private void SatBrightCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		_isDraggingCanvas = true;
		SatBrightCanvas.CaptureMouse();
		UpdateFromCanvasPosition(e.GetPosition(SatBrightCanvas));
	}

	private void SatBrightCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		_isDraggingCanvas = false;
		SatBrightCanvas.ReleaseMouseCapture();
	}

	private void SatBrightCanvas_MouseMove(object sender, MouseEventArgs e)
	{
		if (_isDraggingCanvas && e.LeftButton == MouseButtonState.Pressed)
			UpdateFromCanvasPosition(e.GetPosition(SatBrightCanvas));
	}

	private void UpdateFromCanvasPosition(Point position)
	{
		double w = SatBrightCanvas.ActualWidth;
		double h = SatBrightCanvas.ActualHeight;
		if (w <= 0 || h <= 0)
			return;

		double sat = Math.Clamp(position.X / w, 0, 1);
		double bright = Math.Clamp(1.0 - (position.Y / h), 0, 1);
		double hue = HueSlider.Value;

		PlaceCrosshair(sat, bright);
		SetSelectedColorFromHsb(hue, sat, bright);
	}

	private void PlaceCrosshair(double sat, double bright)
	{
		double w = SatBrightCanvas.ActualWidth;
		double h = SatBrightCanvas.ActualHeight;
		Canvas.SetLeft(Crosshair, (sat * w) - (Crosshair.Width / 2));
		Canvas.SetTop(Crosshair, ((1 - bright) * h) - (Crosshair.Height / 2));
	}

	// -------------------------------------------------------------------------
	// Hue slider
	// -------------------------------------------------------------------------

	private void HueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		if (_isUpdating)
			return;

		UpdateHueGradient(e.NewValue);

		// Recompute color from current hue + canvas position
		double w = SatBrightCanvas.ActualWidth;
		double h = SatBrightCanvas.ActualHeight;
		if (w > 0 && h > 0)
		{
			double sat = Math.Clamp((Canvas.GetLeft(Crosshair) + (Crosshair.Width / 2)) / w, 0, 1);
			double bright = Math.Clamp(1.0 - ((Canvas.GetTop(Crosshair) + (Crosshair.Height / 2)) / h), 0, 1);
			SetSelectedColorFromHsb(e.NewValue, sat, bright);
		}
	}

	private void UpdateHueGradient(double hue)
	{
		Color pureHue = HsbToMediaColor(hue, 1, 1);
		HueGradientRect.Fill = new LinearGradientBrush(
			[
				new(Colors.White, 0),
				new(pureHue, 1)
			],
			new Point(0, 0),
			new Point(1, 0));
	}

	// -------------------------------------------------------------------------
	// RGB sliders
	// -------------------------------------------------------------------------

	private void RgbSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		if (_isUpdating)
			return;

		byte r = (byte)RedSlider.Value;
		byte g = (byte)GreenSlider.Value;
		byte b = (byte)BlueSlider.Value;

		UpdateSliderGradients(r, g, b);
		SyncTextBoxesFromRgb(r, g, b);

		_isUpdating = true;
		try
		{
			SetSelectedColorFromRgb(r, g, b);
		}
		finally
		{
			_isUpdating = false;
		}
	}

	// -------------------------------------------------------------------------
	// Hex input
	// -------------------------------------------------------------------------

	private void HexTextBox_LostFocus(object sender, RoutedEventArgs e)
		=> TryApplyHex();

	private void HexApplyButton_Click(object sender, RoutedEventArgs e)
		=> TryApplyHex();

	private void TryApplyHex()
	{
		string hex = HexTextBox.Text.Trim().TrimStart('#');
		if (hex.Length == 6 && TryParseHex(hex, out byte r, out byte g, out byte b))
		{
			_isUpdating = true;
			try
			{
				RedSlider.Value = r;
				GreenSlider.Value = g;
				BlueSlider.Value = b;
			}
			finally
			{
				_isUpdating = false;
			}

			UpdateSliderGradients(r, g, b);
			SyncTextBoxesFromRgb(r, g, b);
			SetSelectedColorFromRgb(r, g, b);
		}
		else
		{
			// Revert to current color
			SyncHexFromRgb((byte)RedSlider.Value, (byte)GreenSlider.Value, (byte)BlueSlider.Value);
		}
	}

	// -------------------------------------------------------------------------
	// Channel text boxes
	// -------------------------------------------------------------------------

	private void ChannelTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		=> e.Handled = !e.Text.All(char.IsDigit);

	private void ChannelTextBox_LostFocus(object sender, RoutedEventArgs e)
	{
		if (sender is not TextBox tb)
			return;

		if (!byte.TryParse(tb.Text, out byte value))
		{
			// Revert to slider value
			if (tb == RedTextBox) tb.Text = ((byte)RedSlider.Value).ToString(CultureInfo.InvariantCulture);
			else if (tb == GreenTextBox) tb.Text = ((byte)GreenSlider.Value).ToString(CultureInfo.InvariantCulture);
			else if (tb == BlueTextBox) tb.Text = ((byte)BlueSlider.Value).ToString(CultureInfo.InvariantCulture);
			return;
		}

		_isUpdating = true;
		try
		{
			if (tb == RedTextBox) RedSlider.Value = value;
			else if (tb == GreenTextBox) GreenSlider.Value = value;
			else if (tb == BlueTextBox) BlueSlider.Value = value;
		}
		finally
		{
			_isUpdating = false;
		}

		byte r = (byte)RedSlider.Value;
		byte g = (byte)GreenSlider.Value;
		byte b = (byte)BlueSlider.Value;

		UpdateSliderGradients(r, g, b);
		SyncHexFromRgb(r, g, b);
		SetSelectedColorFromRgb(r, g, b);
	}

	// -------------------------------------------------------------------------
	// Sync helpers
	// -------------------------------------------------------------------------

	private void SyncFromSelectedColor(System.Drawing.Color color)
	{
		_isUpdating = true;
		try
		{
			RedSlider.Value = color.R;
			GreenSlider.Value = color.G;
			BlueSlider.Value = color.B;

			(double hue, double sat, double bright) = RgbToHsb(color.R, color.G, color.B);
			HueSlider.Value = hue;

			UpdateHueGradient(hue);
			UpdateSliderGradients(color.R, color.G, color.B);
			SyncTextBoxesFromRgb(color.R, color.G, color.B);
			SyncHexFromRgb(color.R, color.G, color.B);

			OldColorRect.Fill = new SolidColorBrush(Color.FromRgb(color.R, color.G, color.B));
			NewColorRect.Fill = new SolidColorBrush(Color.FromRgb(color.R, color.G, color.B));

			// Position the crosshair
			if (SatBrightCanvas.ActualWidth > 0)
				PlaceCrosshair(sat, bright);
		}
		finally
		{
			_isUpdating = false;
		}
	}

	private void SetSelectedColorFromRgb(byte r, byte g, byte b)
	{
		NewColorRect.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));

		_isUpdating = true;
		try
		{
			SelectedColor = System.Drawing.Color.FromArgb(255, r, g, b);
		}
		finally
		{
			_isUpdating = false;
		}
	}

	private void SetSelectedColorFromHsb(double hue, double sat, double bright)
	{
		Color mediaColor = HsbToMediaColor(hue, sat, bright);
		SyncTextBoxesFromRgb(mediaColor.R, mediaColor.G, mediaColor.B);
		SyncHexFromRgb(mediaColor.R, mediaColor.G, mediaColor.B);

		_isUpdating = true;
		try
		{
			RedSlider.Value = mediaColor.R;
			GreenSlider.Value = mediaColor.G;
			BlueSlider.Value = mediaColor.B;
		}
		finally
		{
			_isUpdating = false;
		}

		UpdateSliderGradients(mediaColor.R, mediaColor.G, mediaColor.B);
		NewColorRect.Fill = new SolidColorBrush(mediaColor);

		_isUpdating = true;
		try
		{
			SelectedColor = System.Drawing.Color.FromArgb(255, mediaColor.R, mediaColor.G, mediaColor.B);
		}
		finally
		{
			_isUpdating = false;
		}
	}

	private void SyncTextBoxesFromRgb(byte r, byte g, byte b)
	{
		RedTextBox.Text = r.ToString(CultureInfo.InvariantCulture);
		GreenTextBox.Text = g.ToString(CultureInfo.InvariantCulture);
		BlueTextBox.Text = b.ToString(CultureInfo.InvariantCulture);
	}

	private void SyncHexFromRgb(byte r, byte g, byte b)
		=> HexTextBox.Text = $"{r:X2}{g:X2}{b:X2}";

	private void UpdateSliderGradients(byte r, byte g, byte b)
	{
		RedStart.Color = Color.FromRgb(0, g, b);
		RedEnd.Color = Color.FromRgb(255, g, b);
		GreenStart.Color = Color.FromRgb(r, 0, b);
		GreenEnd.Color = Color.FromRgb(r, 255, b);
		BlueStart.Color = Color.FromRgb(r, g, 0);
		BlueEnd.Color = Color.FromRgb(r, g, 255);
	}

	// -------------------------------------------------------------------------
	// Color math
	// -------------------------------------------------------------------------

	private static Color HsbToMediaColor(double hue, double sat, double bright)
	{
		if (sat == 0)
		{
			byte v = (byte)(bright * 255);
			return Color.FromRgb(v, v, v);
		}

		double h = hue / 60.0;
		int i = (int)h;
		double f = h - i;
		double p = bright * (1 - sat);
		double q = bright * (1 - (sat * f));
		double t = bright * (1 - (sat * (1 - f)));

		double r, g, b;
		switch (i % 6)
		{
			case 0: r = bright; g = t; b = p; break;
			case 1: r = q; g = bright; b = p; break;
			case 2: r = p; g = bright; b = t; break;
			case 3: r = p; g = q; b = bright; break;
			case 4: r = t; g = p; b = bright; break;
			default: r = bright; g = p; b = q; break;
		}

		return Color.FromRgb((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
	}

	private static (double hue, double sat, double bright) RgbToHsb(byte r, byte g, byte b)
	{
		double rf = r / 255.0, gf = g / 255.0, bf = b / 255.0;
		double max = Math.Max(rf, Math.Max(gf, bf));
		double min = Math.Min(rf, Math.Min(gf, bf));
		double delta = max - min;

		double hue = 0;
		if (delta > 0)
		{
			hue = max == rf ? 60 * ((gf - bf) / delta % 6) : max == gf ? 60 * (((bf - rf) / delta) + 2) : 60 * (((rf - gf) / delta) + 4);
		}

		if (hue < 0) hue += 360;

		double sat = max == 0 ? 0 : delta / max;
		return (hue, sat, max);
	}

	private static bool TryParseHex(string hex, out byte r, out byte g, out byte b)
	{
		r = g = b = 0;
		if (hex.Length != 6) return false;
		try
		{
			r = Convert.ToByte(hex[..2], 16);
			g = Convert.ToByte(hex[2..4], 16);
			b = Convert.ToByte(hex[4..6], 16);
			return true;
		}
		catch
		{
			return false;
		}
	}
}
