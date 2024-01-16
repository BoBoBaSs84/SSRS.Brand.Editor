using System.Reflection;

using BB84.Extensions;
using BB84.Extensions.Serialization;

using SSRS.Brand.Editor.Domain.Common;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.DomainTests.Models;

[TestClass]
public sealed class ColorsModelTests : DomainTestBase
{
	private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFiles");
	private readonly string _fileName = "colors.json";
	private readonly string _jsonContent;

	public ColorsModelTests()
		=> _jsonContent = File.ReadAllText(Path.Combine(_filePath, _fileName));

	[TestMethod]
	public void ColorsModelRegisterTest()
	{
		ColorsModel? model;

		model = GetService<ColorsModel>();

		Assert.IsNotNull(model);
		Assert.IsNotNull(model.Interface);
		Assert.IsNotNull(model.Theme);
	}

	[DataTestMethod]
	[DataRow("UniversalBrand", "1.0.0")]
	public void ColorsModelConstructorTest(string name, string version)
	{
		ColorsModel? model;

		model = new(name, version);

		Assert.IsNotNull(model);
		Assert.AreEqual(name, model.Name);
		Assert.AreEqual(version, model.Version);
		Assert.IsNotNull(model.Interface);
		Assert.IsNotNull(model.Theme);
	}

	[TestMethod]
	public void ColorsToJsonTest()
	{
		ColorsModel model = new() { Version = "1.0.1", Name = "UnitTest" };

		string jsonString = model.ToJson(DomainStatics.SerializerOptions);

		Assert.IsFalse(jsonString.IsNullOrWhiteSpace());
	}

	[TestMethod]
	public void ColorsFromJsonTest()
	{
		ColorsModel? model;

		model = _jsonContent.FromJson<ColorsModel>(DomainStatics.SerializerOptions);

		Assert.IsNotNull(model);
		Assert.AreEqual("Default brand", model.Name);
		Assert.AreEqual("1.0", model.Version);
		Assert.IsNotNull(model.Interface);
		Assert.IsNotNull(model.Theme);
	}
}
