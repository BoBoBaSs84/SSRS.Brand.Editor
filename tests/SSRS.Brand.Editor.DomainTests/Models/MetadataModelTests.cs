using BB84.Extensions.Serialization;

using SSRS.Brand.Editor.Domain.Models;

namespace SSRS.Brand.Editor.Domain.Tests.Models;

[TestClass]
public class MetadataModelTests : DomainTestBase
{
	private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResources");
	private readonly string _fileName = "metadata.xml";

	[TestMethod]
	public void MetadataModelRegisterTest()
	{
		MetadataModel? model;

		model = new MetadataModel();

		Assert.IsNotNull(model);
	}

	[DataTestMethod]
	[DataRow("UniversalBrand", "1.0.0", "Unit test brand without logo.")]
	public void MetadataToXmlTest(string type, string version, string name)
	{
		string keyValue = nameof(keyValue);
		string pathValue = nameof(pathValue);
		MetadataModel metadata = new() { Type = type, Version = version, Name = name };
		metadata.Items.Add(new() { Key = keyValue, Path = pathValue });

		string xmlString = metadata.ToXml();
		MetadataModel xmlModel = xmlString.FromXml<MetadataModel>();

		Assert.IsNotNull(xmlModel);
		Assert.AreEqual(type, xmlModel.Type);
		Assert.AreEqual(name, xmlModel.Name);
		Assert.AreEqual(version, xmlModel.Version);
		Assert.AreEqual(1, xmlModel.Items.Count);
		Assert.AreEqual(keyValue, xmlModel.Items.First().Key);
		Assert.AreEqual(pathValue, xmlModel.Items.First().Path);
	}

	[TestMethod]
	public void MetadataFromXmlTest()
	{
		string xmlContent = File.ReadAllText(Path.Combine(_filePath, _fileName));

		MetadataModel metadata = xmlContent.FromXml<MetadataModel>();

		Assert.IsNotNull(metadata);
		Assert.AreEqual("UniversalBrand", metadata.Type);
		Assert.AreEqual("2.0.2", metadata.Version);
		Assert.AreEqual("Example brand with logo", metadata.Name);
		Assert.AreEqual(2, metadata.Items.Count);
	}
}
