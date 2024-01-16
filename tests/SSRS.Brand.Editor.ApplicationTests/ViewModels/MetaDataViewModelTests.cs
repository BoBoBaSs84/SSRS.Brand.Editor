using SSRS.Brand.Editor.Application.ViewModels;

namespace SSRS.Brand.Editor.ApplicationTests.ViewModels;

[TestClass]
public sealed class MetaDataViewModelTests : ApplicationTestBase
{
	[TestMethod]
	public void MetaDataViewModelRegisterTest()
	{
		MetaDataViewModel? model;

		model = GetService<MetaDataViewModel>();

		Assert.IsNotNull(model);
		Assert.IsNotNull(model.Model);
	}
}
