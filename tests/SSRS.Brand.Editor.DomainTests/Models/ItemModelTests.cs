using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.DomainTests.Models;

[TestClass]
public sealed class ItemModelTests : DomainTestBase
{
	[TestMethod]
	public void ItemModelRegisterTest()
	{
		ItemModel? model;

		model = GetService<ItemModel>();

		Assert.IsNotNull(model);
	}

	[DataTestMethod]
	[DataRow("Key", "Path")]
	public void ItemModelConstructorTest(string key, string path)
	{
		ItemModel? model;

		model = new(key, path);

		Assert.IsNotNull(model);
		Assert.AreEqual(key, model.Key);
		Assert.AreEqual(path, model.Path);
	}
}
