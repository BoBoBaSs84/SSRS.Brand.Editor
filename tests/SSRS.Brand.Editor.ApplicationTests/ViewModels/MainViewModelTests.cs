using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.ApplicationTests.ViewModels;

[TestClass]
public sealed class MainViewModelTests : ApplicationTestBase
{
	[TestMethod]
	public void MainViewModelRegisterTest()
	{
		MainViewModel? model;

		model = GetService<MainViewModel>();

		Assert.IsNotNull(model);
	}
}
