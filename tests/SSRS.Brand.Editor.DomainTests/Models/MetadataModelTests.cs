using BB84.Extensions;
using BB84.Extensions.Serialization;

using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.DomainTests.Models;

[TestClass]
public class MetadataModelTests : DomainTestBase
{
	private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFiles");
	private readonly string _fileName = "metadata.xml";
	private readonly string _xmlContent;

	public MetadataModelTests()
		=> _xmlContent = File.ReadAllText(Path.Combine(_filePath, _fileName));

	[TestMethod]
	public void MetadataModelRegisterTest()
	{
		MetadataModel? model;

		model = GetService<MetadataModel>();

		Assert.IsNotNull(model);
	}

	[DataTestMethod]
	[DataRow("UniversalBrand", "1.0.0", "Unit test brand without logo.")]
	public void MetadataModelConstructorTest(string type, string version, string name)
	{
		MetadataModel? model;

		model = new(type, version, name) { Items = [] };

		Assert.IsNotNull(model);
		Assert.AreEqual(type, model.Type);
		Assert.AreEqual(version, model.Version);
		Assert.AreEqual(name, model.Name);
		Assert.IsNotNull(model.Items);
	}

	[TestMethod]
	public void MetadataToXmlTest()
	{
		MetadataModel metadata = new() { Type = "UniversalBrand", Version = "1.0.0", Name = "Unit test brand without logo." };
		metadata.Items.Add(new() { Key = "colors", Path = "colors.json" });

		string xmlString = metadata.ToXml();

		Assert.IsFalse(xmlString.IsNullOrWhiteSpace());
	}

	[TestMethod]
	public void MetadataFromXmlTest()
	{
		MetadataModel? metadata;

		metadata = _xmlContent.FromXml<MetadataModel>();

		Assert.IsNotNull(metadata);
		Assert.AreEqual("UniversalBrand", metadata.Type);
		Assert.AreEqual("2.0.2", metadata.Version);
		Assert.AreEqual("Example brand with logo", metadata.Name);
		Assert.AreEqual(2, metadata.Items.Count);
	}
}
