using BB84.Extensions.Serialization;

using SSRS.Brand.Editor.Domain.Common;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Tests.Models;

[TestClass]
public sealed class ColorsModelTests : DomainTestBase
{
	private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResources");
	private readonly string _fileName = "colors.json";

	[TestMethod]
	public void ColorsModelRegisterTest()
	{
		ColorsModel? model;

		model = new ColorsModel();

		Assert.IsNotNull(model);
	}

	[DataTestMethod]
	[DataRow("UnitTest", "1.0.1")]
	public void ColorsToJsonTest(string name, string version)
	{
		ColorsModel model = new() { Name = name, Version = version };

		string jsonString = model.ToJson(DomainStatics.SerializerOptions);
		ColorsModel jsonModel = jsonString.FromJson<ColorsModel>(DomainStatics.SerializerOptions);

		Assert.IsNotNull(jsonModel);
		Assert.AreEqual(name, jsonModel.Name);
		Assert.AreEqual(version, jsonModel.Version);
	}

	[TestMethod]
	public void ColorsFromJsonTest()
	{
		string jsonContent = File.ReadAllText(Path.Combine(_filePath, _fileName));

		ColorsModel model = jsonContent.FromJson<ColorsModel>(DomainStatics.SerializerOptions);

		Assert.IsNotNull(model);
		Assert.AreEqual("Default brand", model.Name);
		Assert.AreEqual("1.0", model.Version);
		Assert.IsNotNull(model.Interface);
		Assert.IsNotNull(model.Theme);
	}
}
