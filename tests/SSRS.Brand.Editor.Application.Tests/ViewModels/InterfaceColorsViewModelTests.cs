using SSRS.Brand.Editor.Application.ViewModels;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.Tests.ViewModels;

[TestClass]
public sealed class InterfaceColorsViewModelTests : ApplicationTestBase
{
	[TestMethod]
	public void ConstructorShouldSetModel()
	{
		InterfaceColorsModel model = new();

		InterfaceColorsViewModel viewModel = new(model);

		Assert.AreEqual(model, viewModel.Model);
	}
}
