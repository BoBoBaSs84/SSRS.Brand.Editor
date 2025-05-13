using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.Presentation.Forms;
/// <summary>
/// The form for the about page.
/// </summary>
public partial class AboutForm : Form
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AboutForm"/> class.
	/// </summary>
	/// <param name="viewModel">The view model instance to use.</param>
	public AboutForm(AboutViewModel viewModel)
	{
		InitializeComponent();

		titleLabelValue.Text = viewModel.Model.Title;
		versionLabelValue.Text = viewModel.Model.Version;
		companyLabelValue.Text = viewModel.Model.Company;
		copyrightLabelValue.Text = viewModel.Model.Copyright;
		frameworkLabelValue.Text = viewModel.Model.FrameworkName;
		repositoryLabelValue.Text = viewModel.Model.Repository;
		descriptionLabelValue.Text = viewModel.Model.Comments;
	}
}
