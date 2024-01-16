using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.ApplicationTests.ViewModels;

[TestClass]
public sealed class ColorsViewModelTests : ApplicationTestBase
{
	[TestMethod]
	public void ColorsViewModelRegisterTest()
	{
		ColorsViewModel? model;

		model = GetService<ColorsViewModel>();

		Assert.IsNotNull(model);
		Assert.IsNotNull(model.Model);
	}
}
