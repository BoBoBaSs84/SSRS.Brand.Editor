using BB84.Extensions.Serialization;

using SSRS.Brand.Editor.Domain.Common;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.DomainTests.Models;

[TestClass, ExcludeFromCodeCoverage]
public class ColorsTests
{
	private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFiles");
	private readonly string _fileName = "colors.json";
	private readonly string _jsonContent;

	public ColorsTests()
		=> _jsonContent = File.ReadAllText(Path.Combine(_filePath, _fileName));

	[TestMethod]
	public void ColorsToJsonTest()
	{
		Colors colors = new();

		string jsonString = colors.ToJson(DomainStatics.SerializerOptions);

		Assert.IsFalse(string.IsNullOrWhiteSpace(jsonString));
	}

	[TestMethod]
	public void ColorsFromJsonTest()
	{
		Colors colors;

		colors = _jsonContent.FromJson<Colors>(DomainStatics.SerializerOptions);

		Assert.IsFalse(string.IsNullOrWhiteSpace(colors.Name));
	}
}
