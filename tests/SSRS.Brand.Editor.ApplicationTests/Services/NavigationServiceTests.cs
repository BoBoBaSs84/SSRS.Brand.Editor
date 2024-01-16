using SSRS.Brand.Editor.Application.Interfaces.Application.Services;
using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.ApplicationTests.Services;

[TestClass]
public sealed class NavigationServiceTests : ApplicationTestBase
{
	[TestMethod]
	public void NavigateToTest()
	{
		INavigationService? service = GetService<INavigationService>();

		service.NavigateTo<MainViewModel>();

		Assert.IsNotNull(service);
		Assert.IsInstanceOfType(service.CurrentView, typeof(MainViewModel));
	}
}
