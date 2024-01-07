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
	public void ColorsToJsonTest()
	{
		ColorsModel colors = new() { Version = "1.0.1", Name = "UnitTest" };

		string jsonString = colors.ToJson(DomainStatics.SerializerOptions);

		Assert.IsFalse(jsonString.IsNullOrWhiteSpace());
	}

	[TestMethod]
	public void ColorsFromJsonTest()
	{
		ColorsModel? colors;

		colors = _jsonContent.FromJson<ColorsModel>(DomainStatics.SerializerOptions);

		Assert.IsNotNull(colors);
		Assert.AreEqual("Default brand", colors.Name);
		Assert.AreEqual("1.0", colors.Version);
	}
}
