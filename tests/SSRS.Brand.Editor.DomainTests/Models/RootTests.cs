using SSRS.Brand.Editor.Domain.Extensions;
using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.DomainTests.Models;

[TestClass, ExcludeFromCodeCoverage]
public class RootTests
{
	private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFiles");
	private readonly string _fileName = "colors.json";
	private readonly string _jsonContent;

	public RootTests()
		=> _jsonContent = File.ReadAllText(Path.Combine(_filePath, _fileName));

	[TestMethod]
	public void RootToJsonTest()
	{
		Root root = new();

		string jsonString = root.ToJsonString();

		Assert.IsFalse(string.IsNullOrWhiteSpace(jsonString));
	}

	[TestMethod]
	public void RootFromJsonTest()
	{
		Root r = new();

		r = r.FromJsonString(_jsonContent);

		Assert.IsFalse(string.IsNullOrWhiteSpace(r.Name));
	}
}
