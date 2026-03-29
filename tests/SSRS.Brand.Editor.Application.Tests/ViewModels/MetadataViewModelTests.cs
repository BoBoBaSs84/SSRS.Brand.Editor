using SSRS.Brand.Editor.Application.ViewModels;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.Tests.ViewModels;

[TestClass]
public sealed class MetadataViewModelTests : ApplicationTestBase
{
	[TestMethod]
	public void ConstructorShouldSetModel()
	{
		MetadataModel model = new() { Name = "Test", Version = "2.0.2" };

		MetadataViewModel viewModel = new(model);

		Assert.AreEqual(model, viewModel.Model);
		Assert.AreEqual("Test", viewModel.Model.Name);
		Assert.AreEqual("2.0.2", viewModel.Model.Version);
	}
}
