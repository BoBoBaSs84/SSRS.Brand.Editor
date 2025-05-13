namespace SSRS.Brand.Editor.Presentation.Forms;

/// <summary>
/// the second form of the application.
/// </summary>
public partial class SecondForm : Form
{
	/// <summary>
	/// Initializes a new instance of the <see cref="SecondForm"/> class.
	/// </summary>
	public SecondForm()
	{
		InitializeComponent();
		SecondFormLabel.Text = nameof(SecondForm);
	}
}
