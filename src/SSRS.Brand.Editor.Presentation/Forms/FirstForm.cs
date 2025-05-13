namespace SSRS.Brand.Editor.Presentation.Forms;

/// <summary>
/// The first form of the application.
/// </summary>
public partial class FirstForm : Form
{
	/// <summary>
	/// Initializes a new instance of the <see cref="FirstForm"/> class.
	/// </summary>
	public FirstForm()
	{
		InitializeComponent();
		FirstFormLabel.Text = nameof(FirstForm);
	}
}
