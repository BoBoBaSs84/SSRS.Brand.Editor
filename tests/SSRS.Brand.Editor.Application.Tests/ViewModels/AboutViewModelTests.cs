using SSRS.Brand.Editor.Application.ViewModels;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Application.Tests.ViewModels;

[TestClass]
public sealed class AboutViewModelTests
{
	[TestMethod]
	public void ConstructorShouldSetPropertiesCorrect()
	{
		AboutModel model = new();

		AboutViewModel viewModel = new(model);

		Assert.AreEqual(model, viewModel.Model);
	}
}
