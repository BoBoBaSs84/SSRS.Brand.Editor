using SSRS.Brand.Editor.Application.Services;
using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.Application.Tests.Services;

[TestClass]
public sealed class NavigationServiceTests : ApplicationTestBase
{
	[TestMethod]
	public void NavigateToTest()
	{
		AboutViewModel viewModel = new(new());
		NavigationService service = new(t => viewModel);

		service.NavigateTo<AboutViewModel>();

		Assert.IsInstanceOfType(service.CurrentView, typeof(AboutViewModel));
	}
}
