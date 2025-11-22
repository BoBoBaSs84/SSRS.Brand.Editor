using System.Windows.Forms;

using SSRS.Brand.Editor.Application.ViewModels;
using SSRS.Brand.Editor.Domain.Models;
using SSRS.Brand.Editor.Presentation.Forms;

namespace SSRS.Brand.Editor.Presentation.Tests.Forms;
[TestClass]
public sealed class AboutFormTests : UnitTestBase
{
	[TestMethod]
	public void ConstructorShouldSetFieldsCorrectly()
	{
		AboutModel model = new();
		AboutViewModel viewModel = new(model);

		using AboutForm form = new(viewModel);

		Assert.AreEqual(viewModel.Model.Title, ((Label)GetNonPublicField(form, "titleLabelValue")).Text);
		Assert.AreEqual(viewModel.Model.Version, ((Label)GetNonPublicField(form, "versionLabelValue")).Text);
		Assert.AreEqual(viewModel.Model.Company, ((Label)GetNonPublicField(form, "companyLabelValue")).Text);
		Assert.AreEqual(viewModel.Model.Copyright, ((Label)GetNonPublicField(form, "copyrightLabelValue")).Text);
		Assert.AreEqual(viewModel.Model.FrameworkName, ((Label)GetNonPublicField(form, "frameworkLabelValue")).Text);
		Assert.AreEqual(viewModel.Model.Repository, ((Label)GetNonPublicField(form, "repositoryLabelValue")).Text);
		Assert.AreEqual(viewModel.Model.Comments, ((Label)GetNonPublicField(form, "descriptionLabelValue")).Text);
	}
}
